using Providers.Data;
using Providers.Data.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providers.Controller
{
    public class MongoDbController
    {
        public void AddContry(string name, int population) {

            Country newCountry = new Country() 
            { 
                Name = name, 
                Population = population 
            };

            MongoDbProvider.SaveData<Country>(MongoDbProvider.db, newCountry);
        }
    }
}
