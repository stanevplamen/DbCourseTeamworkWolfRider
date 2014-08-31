using CarsStore.Models;
using Providers.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providers.Controllers
{
    /// <summary>
    /// Controller which add classes and operates with MongoDbProvider static class
    /// </summary>
    public class MongoDbController
    {
        /// <summary>
        /// Makes new Country class and adds passes it to the MongoDbProvider to save the class data
        /// </summary>
        /// <param name="name">Contry name</param>
        /// <param name="population">Country population</param>
        public void AddContry(string name, int population) {

            Country newCountry = new Country() 
            { 
                Name = name, 
                Population = population 
            };

            MongoDbProvider.SaveData<Country>(MongoDbProvider.db, newCountry);
            Program.countriesAddedList.Add(newCountry);
        }

        public IQueryable<Country> GetCountriesData()
        {
            var mongoData = MongoDbProvider.LoadData<Country>(MongoDbProvider.db);
            return mongoData;
        }
    }
}
