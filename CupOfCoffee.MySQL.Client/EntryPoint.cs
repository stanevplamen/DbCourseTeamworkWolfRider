namespace CupOfCoffee.MySQL.Client
{
    using System.Collections.Generic;

    using CupOfCoffee.MySQL.Models;
    using Telerik.OpenAccess;

    public class EntryPoint
    {
        static void Main(string[] args)
        {
        }

        public static void AddReports(ICollection<IReport> reports, MySqlModel context)
        {
            using (context)
            {
                foreach (var report in reports)
                {
                    context.Add(report);
                }
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
