using CarsStore.Models;
using Providers.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providers.Controllers
{
    internal class Program
    {
        public static List<Country> countriesAddedList = new List<Country>();

        /// <summary>
        /// Main entry on the program
        /// </summary>
        static void Main()
        {
            MongoDbController mongoDbController = new MongoDbController();
            // // uncomment the first start to add the start data to MongoDb
            AddSampleDataToMongoDb(mongoDbController);

            var mongoContryData = GetMongoDbData(mongoDbController);
            // add mongo db data to ms sql server
            AddDataToMsServer(mongoContryData);
        
        }

        /// <summary>
        /// Loads The passed data to MS Sql Server
        /// </summary>
        /// <param name="mongoContryData"></param>
        private static void AddDataToMsServer(List<Country> mongoContryData)
        {
            var msSqlDb = new CarsStoreContext();

            foreach (var country in mongoContryData)
            {
                msSqlDb.Countries.Add(country);
            }

            msSqlDb.SaveChanges();
        }

        /// <summary>
        /// Get the data from MongoDb
        /// </summary>
        /// <param name="mongoDbController"></param>
        private static List<Country> GetMongoDbData(MongoDbController mongoDbController)
        {
            var mongoData = mongoDbController.GetCountriesData().ToList();
            return mongoData;
        }

        /// <summary>
        /// Add some sample data to MongoDb
        /// </summary>
        /// <param name="mongoDbController"></param>
        private static void AddSampleDataToMongoDb(MongoDbController mongoDbController)
        {
            // Initializing some sample data to add to the MongoDb
            Dictionary<string, int> countriesList = new Dictionary<string, int>()
	            {
                    {"Germany", 80000000},
                    {"Japan", 130000000},
                    {"France", 70000000},
                    {"United States", 320000000},
                    {"Russia", 150000000},
                    {"Italy", 60000000},
                    {"South Korea", 50000000}
	            };

            // Adding the sample data to the MongoDb
            foreach (KeyValuePair<string, int> pair in countriesList)
            {
                mongoDbController.AddContry(pair.Key, pair.Value);
            }
        }     
    }
}
