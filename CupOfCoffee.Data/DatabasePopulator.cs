using CupOfCoffee.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CupOfCoffee.Data
{
    public static class DatabasePopulator
    {
        public static MongoDatabase db;

        static DatabasePopulator()
        {
            string mongoConnectionString = "mongodb://localhost";

            MongoClient client = new MongoClient(mongoConnectionString);
            MongoServer server = client.GetServer();
            db = server.GetDatabase("CupOfCoffee");
        }


        public static void Seed() 
        {
            db.Drop();

            List<Category> categories = GenerateCategories();
            MongoCollection categoryCollection = db.GetCollection("Categories");
            categoryCollection.InsertBatch<Category>(categories);

            List<Product> products = GenerateProducts();
            MongoCollection productCollection = db.GetCollection("Products");
            productCollection.InsertBatch<Product>(products);

            List<CustomerStatus> customerStatuses = GenerateCustomerStatuses();
            MongoCollection customerStatusCollection = db.GetCollection("CustomerStatuses");
            customerStatusCollection.InsertBatch<CustomerStatus>(customerStatuses);

            List<Customer> customers = GenerateCustomers();
            MongoCollection customerCollection = db.GetCollection("Customers");
            customerCollection.InsertBatch<Customer>(customers);

            List<Position> positions = GeneratePositions();
            MongoCollection positionCollection = db.GetCollection("Positions");
            positionCollection.InsertBatch<Position>(positions);

            List<Employee> employees = GenerateEmployees();
            MongoCollection employeeCollection = db.GetCollection("Employees");
            employeeCollection.InsertBatch<Employee>(employees);
        }

        private static List<Category> GenerateCategories()
        {
            List<Category> categories = new List<Category>() 
            {
                new Category { Id = 1, Name = "Coffee" },
                new Category { Id = 2, Name = "Tea"},
                new Category { Id = 3, Name = "Alchohol"},
                new Category { Id = 4, Name = "Cigarettes"},
                new Category { Id = 5, Name = "Food"},
            };

            return categories;
        }

        private static List<Product> GenerateProducts()
        {

            int productId = 1;
            List<Product> products = new List<Product>()
            {
                new Product { Id = productId++, CategoryId = 1, Name = "Espresso", SellPrice = 1m},
                new Product { Id = productId++, CategoryId = 1, Name = "Macchiato", SellPrice = 1.4m},
                new Product { Id = productId++, CategoryId = 1, Name = "Mocha", SellPrice = 2m},
                new Product { Id = productId++, CategoryId = 1, Name = "Turkish coffee", SellPrice = 0.8m},
                new Product { Id = productId++, CategoryId = 1, Name = "Cappuccino", SellPrice = 1.8m},
                new Product { Id = productId++, CategoryId = 2, Name = "Earl Gray", SellPrice = 1.2m},
                new Product { Id = productId++, CategoryId = 2, Name = "Ceylon Tea", SellPrice = 1m},
                new Product { Id = productId++, CategoryId = 2, Name = "Herbal Tea", SellPrice = 0.8m},
                new Product { Id = productId++, CategoryId = 2, Name = "Fruit Tea", SellPrice = 0.9m},
                new Product { Id = productId++, CategoryId = 2, Name = "Masala Chai", SellPrice = 1.5m},
                new Product { Id = productId++, CategoryId = 2, Name = "Masala Chai", SellPrice = 1m},
                new Product { Id = productId++, CategoryId = 3, Name = "Zagorka", SellPrice = 2m},
                new Product { Id = productId++, CategoryId = 3, Name = "Shumensko", SellPrice = 1.8m},
                new Product { Id = productId++, CategoryId = 3, Name = "Ariana Radler", SellPrice = 1.6m},
                new Product { Id = productId++, CategoryId = 3, Name = "Beck's", SellPrice = 2.5m},
                new Product { Id = productId++, CategoryId = 3, Name = "Amstel", SellPrice = 3m},
                new Product { Id = productId++, CategoryId = 4, Name = "Parliament", SellPrice = 6m},
                new Product { Id = productId++, CategoryId = 4, Name = "Victory", SellPrice = 4.5m},
                new Product { Id = productId++, CategoryId = 4, Name = "Muratti", SellPrice = 4.8m},
                new Product { Id = productId++, CategoryId = 4, Name = "Sredets Jult", SellPrice = 4.2m},
                new Product { Id = productId++, CategoryId = 4, Name = "Davidoff Gold", SellPrice = 5.3m},
                new Product { Id = productId++, CategoryId = 5, Name = "Corny", SellPrice = 1.5m},
                new Product { Id = productId++, CategoryId = 5, Name = "Vafli Chaika", SellPrice = 0.8m},
                new Product { Id = productId++, CategoryId = 5, Name = "7 Days Double", SellPrice = 0.7m},
                new Product { Id = productId++, CategoryId = 5, Name = "Gorna Bania 0.5l", SellPrice = 1m},
                new Product { Id = productId++, CategoryId = 5, Name = "Prestige Qdesh Sega ili Gorish", SellPrice = 3.2m},
            };

            return products;
        }

        private static List<CustomerStatus> GenerateCustomerStatuses()
        {
            List<CustomerStatus> statuses = new List<CustomerStatus>()
            {
                new CustomerStatus { Id = 1, Name = "Regular", Discount = 0m},
                new CustomerStatus { Id = 2, Name = "Premium", Discount = 0.1m},
                new CustomerStatus { Id = 3, Name = "VIP", Discount = 0.2m},
            };

            return statuses;
        }

        private static List<Customer> GenerateCustomers()
        {
            int customerId = 1;
            List<Customer> customers = new List<Customer>()
            {
                new Customer { Id = customerId++, Name = "Ivailo Papazov", CustomerStatusId = 1 },
                new Customer { Id = customerId++, Name = "Nikolay Radkov", CustomerStatusId = 1 },
                new Customer { Id = customerId++, Name = "Georgi Kostadinov", CustomerStatusId = 1 },
                new Customer { Id = customerId++, Name = "Ivailo Kenov", CustomerStatusId = 2 },
                new Customer { Id = customerId++, Name = "Doncho Minkov", CustomerStatusId = 2 },
                new Customer { Id = customerId++, Name = "Nikolay Kostov", CustomerStatusId = 3 },
            };

            return customers;
        }

        private static List<Position> GeneratePositions()
        {
            List<Position> positions = new List<Position>() 
            {
                new Position { Id = 1, Name = "Senior Waitress", BaseSalary = 600m},
                new Position { Id = 2, Name = "Junior Waitress", BaseSalary = 400m},
                new Position { Id = 3, Name = "Boss", BaseSalary = 500m},
            };

            return positions;
        }
        private static List<Employee> GenerateEmployees()
        {
            int employeeId = 1;
            List<Employee> employees = new List<Employee>() 
            {
                new Employee { Id = employeeId++, Name = "Viki", PositionId = 1, HireDate = new DateTime(2013, 9, 12) },
                new Employee { Id = employeeId++, Name = "Didi", PositionId = 2, HireDate = new DateTime(2014, 5, 20) },
            };

            return employees;
        }
    }
}
