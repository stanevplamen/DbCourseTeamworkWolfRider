namespace CupOfCoffee.SQLite.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<ProductsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "CupOfCoffee.SQLite.Data.ProductsContext";
        }

        protected override void Seed(ProductsContext context)
        {
        }
    }
}
