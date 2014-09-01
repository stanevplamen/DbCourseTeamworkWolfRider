using RidersCoffees.Models;
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
        /// Makes new CoffeePlace class and adds passes it to the MongoDbProvider to save the class data
        /// </summary>
        /// <param name="name">CoffeePlace name</param>
        /// <param name="seats">CoffeePlace seats</param>
        public void AddCoffeePlace(string name, int seats)
        {

            CoffeePlace newCoffeePlace = new CoffeePlace() 
            { 
                Name = name,
                SeatsNumber = seats 
            };

            MongoDbProvider.SaveData<CoffeePlace>(MongoDbProvider.db, newCoffeePlace);
            Program.coffeesAddedList.Add(newCoffeePlace);
        }

        public IQueryable<CoffeePlace> GetCoffeePlacesData()
        {
            var mongoData = MongoDbProvider.LoadData<CoffeePlace>(MongoDbProvider.db);
            return mongoData;
        }

        public IQueryable<Employee> GetEmployeesData()
        {
            var mongoData = MongoDbProvider.LoadData<Employee>(MongoDbProvider.db);
            return mongoData;
        }

        public void AddEmployees(List<Tuple<string,string, string, string, int, decimal>> emloyeesList)
        {
            foreach (var employeeDetails in emloyeesList)
            {
                Employee newEmployee = new Employee() 
                    {
                        CoffeePlaceMongoId = employeeDetails.Item1,
                        FirstName = employeeDetails.Item2,
                        LastName = employeeDetails.Item3,
                        Position = employeeDetails.Item4,
                        Years = employeeDetails.Item5,
                        Salary = employeeDetails.Item6,
                    };

                MongoDbProvider.SaveData<Employee>(MongoDbProvider.db, newEmployee);
            }
        }



    }
}
