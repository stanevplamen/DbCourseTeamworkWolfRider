using CupOfCoffee.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CupOfCoffee.Controllers.DataLoader
{
    public static class MongoDbExtractor
    {
        public static MongoDatabase db;

        static MongoDbExtractor()
        {
            string mongoConnectionString = "mongodb://localhost";

            MongoClient client = new MongoClient(mongoConnectionString);
            MongoServer server = client.GetServer();
            db = server.GetDatabase("CupOfCoffee");
        }

        public static void ExtractToSqlServer()
        {
            MongoCollection productCollection = db.GetCollection<Product>("Products");
        }
    }
}
