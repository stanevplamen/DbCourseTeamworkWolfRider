using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providers.Controller
{
    internal class Program
    {
        static void Main()
        {
            MongoDbController mongoDbController = new MongoDbController();

            Dictionary<string, int> countriesList = new Dictionary<string, int>()
	            {
	                {"Germany", 120000000},
	                {"Italy", 100000000},
	                {"Japan", 150000000},
	                {"France", 90000000}
	            };

            foreach (KeyValuePair<string, int> pair in countriesList)
	        {
                mongoDbController.AddContry(pair.Key, pair.Value);
	        }
        }
    }
}
