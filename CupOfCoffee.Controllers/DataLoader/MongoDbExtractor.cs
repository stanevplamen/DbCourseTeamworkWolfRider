using CupOfCoffee.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver.Linq;
using CupOfCoffee.Data;

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

        public static void ExtractDataToSqlServer()
        {
            CupOfCoffeeContext sqlDb = new CupOfCoffeeContext();

            var productCollection = db.GetCollection<Product>("Products");
            var products = productCollection.FindAll();
            var categoryCollection = db.GetCollection<Category>("Categories");
            var categories = categoryCollection.FindAll();

            foreach (var category in categories)
            {
                category.Products = products.Where(product => product.CategoryId == category.Id).ToList();
                sqlDb.Categories.Add(category);
            }

            sqlDb.SaveChanges();

            var employeeCollection = db.GetCollection<Employee>("Employees");
            var employees = employeeCollection.FindAll();
            var positionCollection = db.GetCollection<Position>("Positions");
            var positions = positionCollection.FindAll();

            foreach (var position in positions)
            {
                position.Employees = employees.Where(employee => employee.PositionId == position.Id).ToList();
                sqlDb.Positions.Add(position);
            }

            sqlDb.SaveChanges();

            var customerCollection = db.GetCollection<Customer>("Customers");
            var customers = customerCollection.FindAll();
            var customerStatusCollection = db.GetCollection<CustomerStatus>("CustomerStatuses");
            var customerStatuses = customerStatusCollection.FindAll();

            foreach (var status in customerStatuses)
            {
                status.Customers = customers.Where(customer => customer.CustomerStatusId == status.Id).ToList();
                sqlDb.CustomerStatuses.Add(status);
            }

            sqlDb.SaveChanges();
        }
    }
}
