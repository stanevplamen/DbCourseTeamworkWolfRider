namespace CupOfCoffee.MySQL.Client
{
    using System.Collections.Generic;

    using CupOfCoffee.MySQL.Models;
    using Telerik.OpenAccess;

    public class EntryPoint
    {
        static void Main(string[] args)
        {
            ICollection<IProductReport> reps = new List<IProductReport>() 
            {
                new ProductReport(){ ProductID = 1, ProductName="Nova Brasilia", ProductCategory="Coffee", TotalIncome= 3567.5m, TotalQuantitySold=3000 },
                new ProductReport(){ ProductID = 2, ProductName="Nestea", ProductCategory="Tea", TotalIncome= 356.5m, TotalQuantitySold=300 },
                new ProductReport(){ ProductID = 3, ProductName="Zagorka", ProductCategory="Beer", TotalIncome= 242.4m, TotalQuantitySold=100 },
                new ProductReport(){ ProductID = 4, ProductName="Jack", ProductCategory="Whiskey", TotalIncome= 5000, TotalQuantitySold=1000 }
            };

            //UpdateDatabase();
            //MySqlModel context = new MySqlModel();
            //AddReports(reps, context);
        }

        public static void AddReports(ICollection<IProductReport> reports, MySqlModel context)
        {
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
