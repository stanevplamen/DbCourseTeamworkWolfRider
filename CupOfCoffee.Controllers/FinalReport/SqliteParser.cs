namespace CupOfCoffee.Controllers.FinalReport
{
    using System.Collections.Generic;
    using System.Data.SQLite;

    using CupOfCoffee.SQLite.Data.Database;

    public static class SqliteParser
    {
        public static Dictionary<string, VendorsProduct> GetVendorsProducts()
        {
            var sqliteConnection = new SQLiteConnection("Data Source=..\\..\\..\\CupOfCoffee.SQLite.Data\\Database\\products.sqlite");
            var vendorsProducts = new Dictionary<string, VendorsProduct>();

            using (sqliteConnection)
            {
                sqliteConnection.Open();

                var query = "SELECT * FROM VendorProducts";

                var cmd = new SQLiteCommand(query, sqliteConnection);

                var dataReader = cmd.ExecuteReader();

                using (dataReader)
                {
                    while (dataReader.Read())
                    {
                        var id = dataReader.GetInt32(0);
                        var name = dataReader.GetString(1);
                        var basePrice = dataReader.GetInt32(2) / 100.0m;

                        vendorsProducts.Add(name, new VendorsProduct()
                        {
                            Id = id,
                            Name = name,
                            BasePrice = basePrice
                        });
                    }
                }
            }

            return vendorsProducts;
        }
    }
}
