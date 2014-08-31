using Providers.Data.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providers.Controller
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
            // AddSampleDataToMongoDb(mongoDbController);

            GetMongoDbData(mongoDbController);
        
        }

        private static void GetMongoDbData(MongoDbController mongoDbController)
        {
            var mongoData = mongoDbController.GetCountriesData();
            int y = 5;
        }

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
