namespace CupOfCoffee.Controllers.MySqlReports
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Telerik.OpenAccess;
    using Newtonsoft.Json;

    using CupOfCoffee.Data;
    using CupOfCoffee.MySQL.Models;
    
    public static class ProductsReportsLoader
    {
        public static IList<ProductReport> GetProductsSaleInfo(CupOfCoffeeContext context)
        {
            var results = context.Products.Select(p => new ProductReport()
            {
                ProductID = p.Id,
                ProductName = p.Name,
                ProductCategory = p.Category.Name,
                TotalIncome = (Nullable<decimal>)p.OrderDetails.Sum(od => od.Quantity * (p.SellPrice - (od.HappyHour ? 0 : p.SellPrice * 0.25m) - (p.SellPrice * (od.Order.Customer.CustomerStatus.Discount / 100)))) ?? 0,
                TotalQuantitySold = (Nullable<int>)p.OrderDetails.Sum(g => g.Quantity) ?? 0
            }).ToList();

            return results;
        }

        public static void GenerateJsonReports(IList<ProductReport> reports, string path)
        {
            for (var i = 0; i < reports.Count; i++)
            {
                var json = JsonConvert.SerializeObject(reports[i], Formatting.Indented);
                var fileName = reports[i].ProductID + ".json";

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

        public static IList<ProductReport> GetReportsFromMySql(MySqlModel context)
        {
            var reports = new List<ProductReport>();

            using (context)
            {
                reports = context.GetAll<ProductReport>().ToList();
            }

            return reports;
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
