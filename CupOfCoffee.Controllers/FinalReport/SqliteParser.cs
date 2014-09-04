namespace CupOfCoffee.Controllers.FinalReport
{
    using System.Collections.Generic;
    using System.Data.SQLite;
    using System.Linq;

    using CupOfCoffee.SQLite.Data;
    using CupOfCoffee.SQLite.Data.DatabaseSqlite;

    public static class SqliteParser
    {
        public static Dictionary<string, VendorsProduct> GetVendorsProducts()
        {
            var sqliteContext = new ProductsContext();

            if (sqliteContext.VendorsProducts.Count() == 0)
            {
                ProductsPopulator.Populate(sqliteContext);
            }
            
            var vendorsProducts = new Dictionary<string, VendorsProduct>();
            var vendorsProductsAsList = new List<VendorsProduct>();

            using(sqliteContext)
            {
                vendorsProductsAsList = sqliteContext.VendorsProducts.ToList();
            }


            foreach (var product in vendorsProductsAsList)
            {
                vendorsProducts.Add(product.Name, product);
            }

            return vendorsProducts;
        }
    }
}
