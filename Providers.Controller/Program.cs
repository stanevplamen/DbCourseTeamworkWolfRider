using RidersCoffees.Models;
using Providers.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CupOfCoffee.Data;

namespace Providers.Controllers
{
    internal class Program
    {
        public static List<CoffeePlace> coffeesAddedList = new List<CoffeePlace>();

        /// <summary>
        /// Main entry on the program
        /// </summary>
        static void Main()
        {
            var db = new CupOfCoffeeContext();
            var categories = db.Categories.ToList();

            MongoDbController mongoDbController = new MongoDbController();
            // // uncomment the first start to add the start data to MongoDb
           //AddSampleDataToMongoDb(mongoDbController);

           var mongoCoffeePlacesData = GetMongoDbData(mongoDbController);
            // add mongo db data to ms sql server
           AddDataToMsServer(mongoCoffeePlacesData);
        
        }

        /// <summary>
        /// Loads The passed data to MS Sql Server
        /// </summary>
        /// <param name="mongoContryData"></param>
        private static void AddDataToMsServer(List<CoffeePlace> mongoCoffeePlacesData)
        {
            var msSqlDb = new RidersCoffeesContext();

            foreach (var coffeePlace in mongoCoffeePlacesData)
            {
                msSqlDb.CoffeePlaces.Add(coffeePlace);
            }

            msSqlDb.SaveChanges();
        }

        /// <summary>
        /// Get the data from MongoDb
        /// </summary>
        /// <param name="mongoDbController"></param>
        private static List<CoffeePlace> GetMongoDbData(MongoDbController mongoDbController)
        {
            var mongoCoffeePlacesData = mongoDbController.GetCoffeePlacesData().ToList();
            var mongoEmployeesData = mongoDbController.GetEmployeesData().ToList();

            // attaching the relations 1:many -> CoffeePlace : Employee
            foreach (var coffeePlace in mongoCoffeePlacesData)
            {
                foreach (var employee in mongoEmployeesData)
                {
                    if (coffeePlace._id.ToString() == employee.CoffeePlaceMongoId)
                    {
                        coffeePlace.Employees.Add(employee);
                    }
                }
            }

            return mongoCoffeePlacesData;
        }

        /// <summary>
        /// Add some sample data to MongoDb
        /// </summary>
        /// <param name="mongoDbController"></param>
        private static void AddSampleDataToMongoDb(MongoDbController mongoDbController)
        {
            // Initializing some sample data to add to the MongoDb
            Dictionary<string, int> coffeesList = new Dictionary<string, int>()
	            {
                    {"Telerik Mladost Coffee", 60},
                    {"Telerik Nigth Bar", 110},
                    {"Telerik Sport Center Coffee", 40},
                    {"Telerik Breakfast Bar", 30},
                    {"Telerik Healthy Restaurant", 45}
	            };

            // Adding the sample data to the MongoDb
            foreach (KeyValuePair<string, int> pair in coffeesList)
            {
                mongoDbController.AddCoffeePlace(pair.Key, pair.Value);
            }

            // here we get the already stored data from mongodb
            foreach (var coffeePlace in coffeesAddedList)
            {

                switch (coffeePlace.Name)
                {
                    case "Telerik Mladost Coffee":
                        var emloyeesListOne = new List<Tuple<string, string, string, string, int, decimal>>
                        {
                            new Tuple<string,string, string, string, int, decimal>(coffeePlace._id.ToString(), "Hristina", "Kovacheva", "waitress", 25, 1300.0m),
                            new Tuple<string,string, string, string, int, decimal>(coffeePlace._id.ToString(), "Gergana", "Dimitrova", "waitress", 20, 1300.0m),
                            new Tuple<string,string, string, string, int, decimal>(coffeePlace._id.ToString(), "Svoboda", "Ivanova", "waitress", 23, 1300.0m),
                            new Tuple<string,string, string, string, int, decimal>(coffeePlace._id.ToString(), "Denitsa", "Hristova", "manager", 28, 1600.0m)
                        };

                        mongoDbController.AddEmployees(emloyeesListOne);
                        break;
                    case "Telerik Nigth Bar":
                        var emloyeesListTwo = new List<Tuple<string, string, string, string, int, decimal>>
                        {
                            new Tuple<string,string, string, string, int, decimal>(coffeePlace._id.ToString(), "Ivan", "Georgiev", "barman", 25, 1300.0m),
                            new Tuple<string,string, string, string, int, decimal>(coffeePlace._id.ToString(), "Hristo", "Stefanov", "barman", 20, 1300.0m),
                            new Tuple<string,string, string, string, int, decimal>(coffeePlace._id.ToString(), "Cvetomir", "Kovachev", "barman", 23, 1300.0m),
                            new Tuple<string,string, string, string, int, decimal>(coffeePlace._id.ToString(), "Kalina", "Dimcheva", "waitress", 23, 1300.0m),
                            new Tuple<string,string, string, string, int, decimal>(coffeePlace._id.ToString(), "Cveta", "Stoichnova", "waitress", 21, 1300.0m),
                            new Tuple<string,string, string, string, int, decimal>(coffeePlace._id.ToString(), "Monika", "Ilieva", "manager", 32, 1600.0m)
                        };

                        mongoDbController.AddEmployees(emloyeesListTwo);
                        break;
                    case "Telerik Sport Center Coffee":
                        Console.WriteLine("Case 2");
                        break;
                    case "Telerik Breakfast Bar":
                        Console.WriteLine("Case 2");
                        break;
                    case "Telerik Healthy Restaurant":
                        Console.WriteLine("Case 2");
                        break;
                    default:
                        throw new NotImplementedException("The given coffee do not exists");
                }

            }

           
        }     
    }
}
