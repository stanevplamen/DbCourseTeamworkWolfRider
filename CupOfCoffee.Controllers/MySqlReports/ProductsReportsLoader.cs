using CupOfCoffee.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using CupOfCoffee.MySQL.Models;
using Telerik.OpenAccess;

namespace CupOfCoffee.Controllers.MySqlReports
{

    public static class ProductsReportsLoader
    {
        public static IList<ProductReport> GetProductsSaleInfo(CupOfCoffeeContext context)
        {
            var results = context.Products.Select(p => new ProductReport()
            {
                ProductID = p.Id,
                ProductName = p.Name,
                ProductCategory = p.Category.Name,
                TotalIncome = p.OrderDetails.Sum(od => od.Quantity * (p.SellPrice - (od.HappyHour ? 0 : p.SellPrice * 0.25m) - (p.SellPrice * (od.Order.Customer.CustomerStatus.Discount / 100)))),
                TotalQuantitySold = p.OrderDetails.Sum(g => g.Quantity)
            }).ToList();

            return results;
        }

        public static void GenerateJsonReports(IList<ProductReport> reports, string path)
        {
            for (int i = 0; i < reports.Count; i++)
            {
                string json = JsonConvert.SerializeObject(reports[i], Formatting.Indented);
                string fileName = reports[i].ProductID + ".json";

                using (var writer = new StreamWriter(path + fileName))
                {
                    writer.Write(json);
                }
            }
        }

        public static void AddReports(ICollection<ProductReport> reports, MySqlModel context)
        {
            UpdateDatabase();
            using (context)
            {
                foreach (var report in reports)
                {
                    context.Add(report);
                }
                context.SaveChanges();
            }
        }

        private static void UpdateDatabase()
        {
            using (var context = new MySqlModel())
            {
                var schemaHandler = context.GetSchemaHandler();
                EnsureDB(schemaHandler);
            }
        }

        private static void EnsureDB(ISchemaHandler schemaHandler)
        {
            string script = null;
            if (schemaHandler.DatabaseExists())
            {
                script = schemaHandler.CreateUpdateDDLScript(null);
            }
            else
            {
                schemaHandler.CreateDatabase();
                script = schemaHandler.CreateDDLScript();
            }

            if (!string.IsNullOrEmpty(script))
            {
                schemaHandler.ExecuteDDLScript(script);
            }
        }
    }
}
