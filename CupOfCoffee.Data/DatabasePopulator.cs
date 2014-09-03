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
                new Category { Id = 6, Name = "Snack"},
                new Category { Id = 7, Name = "Vegerables"},
                new Category { Id = 8, Name = "Fruits"},
                new Category { Id = 9, Name = "Nuts"},
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
                new Product { Id = productId++, CategoryId = 6, Name = "Croissant 7Days", SellPrice = 1.1m},
                new Product { Id = productId++, CategoryId = 6, Name = "Croissant Fresh Baked", SellPrice = 1.2m},
                new Product { Id = productId++, CategoryId = 6, Name = "Toast sandwitch", SellPrice = 1.2m},
                new Product { Id = productId++, CategoryId = 7, Name = "Аvocado", SellPrice = 3.5m},
                new Product { Id = productId++, CategoryId = 7, Name = "Olives", SellPrice = 2.4m},
                new Product { Id = productId++, CategoryId = 8, Name = "Lemon", SellPrice = 0.5m},
                new Product { Id = productId++, CategoryId = 8, Name = "Banana", SellPrice = 0.5m},
                new Product { Id = productId++, CategoryId = 8, Name = "Orange", SellPrice = 0.4m},
                new Product { Id = productId++, CategoryId = 9, Name = "Almonds", SellPrice = 3.1m},
                new Product { Id = productId++, CategoryId = 9, Name = "Peanuts", SellPrice = 2.1m},
                new Product { Id = productId++, CategoryId = 9, Name = "Hazelnuts", SellPrice = 2.1m},
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
                new Position { Id = 1, Name = "Senior Waitress", BaseSalary = 1400m},
                new Position { Id = 2, Name = "Junior Waitress", BaseSalary = 1100m},
                new Position { Id = 3, Name = "General Director", BaseSalary = 2500m},
                new Position { Id = 4, Name = "Manager", BaseSalary = 1500m},
                new Position { Id = 5, Name = "Marketing", BaseSalary = 1500m},
                new Position { Id = 6, Name = "Traider", BaseSalary = 1500m},
                new Position { Id = 7, Name = "Buyer", BaseSalary = 1500m},
                new Position { Id = 8, Name = "Hostess", BaseSalary = 1100m},
                new Position { Id = 9, Name = "Barman", BaseSalary = 1100m},
            };

            return positions;
        }
        private static List<Employee> GenerateEmployees()
        {
            int employeeId = 1;
            List<Employee> employees = new List<Employee>() 
            {
                new Employee { Id = employeeId++, Name = "Viki Hristova", PositionId = 1, HireDate = new DateTime(2012, 9, 12) },
                new Employee { Id = employeeId++, Name = "Didi Jeliazkova", PositionId = 2, HireDate = new DateTime(2014, 5, 20) },
                new Employee { Id = employeeId++, Name = "Iva Mihailova", PositionId = 2, HireDate = new DateTime(2013, 5, 20) },
                new Employee { Id = employeeId++, Name = "Ceca Cvetanova", PositionId = 2, HireDate = new DateTime(2013, 5, 21) },
                new Employee { Id = employeeId++, Name = "Pepa Pepinova", PositionId = 2, HireDate = new DateTime(2013, 7, 22) },
                new Employee { Id = employeeId++, Name = "Gina Stoichkova", PositionId = 2, HireDate = new DateTime(2013, 3, 23) },
                new Employee { Id = employeeId++, Name = "Didi Ivanova", PositionId = 2, HireDate = new DateTime(2014, 1, 24) },
                new Employee { Id = employeeId++, Name = "Pano Hristov", PositionId = 3, HireDate = new DateTime(2011, 1, 24) },
                new Employee { Id = employeeId++, Name = "Momchil Cvetanov", PositionId = 4, HireDate = new DateTime(2012, 2, 18) },
                new Employee { Id = employeeId++, Name = "Milena Rangelova", PositionId = 5, HireDate = new DateTime(2013, 4, 24) },
                new Employee { Id = employeeId++, Name = "Evgeni Stoinev", PositionId = 6, HireDate = new DateTime(2013, 5, 13) },
                new Employee { Id = employeeId++, Name = "Hristo Pachev", PositionId = 7, HireDate = new DateTime(2013, 5, 14) },
                new Employee { Id = employeeId++, Name = "Maria Mihova", PositionId = 8, HireDate = new DateTime(2013, 2, 14) },
                new Employee { Id = employeeId++, Name = "Ivan Mihov", PositionId = 9, HireDate = new DateTime(2014, 3, 10) },
                new Employee { Id = employeeId++, Name = "Mitko Ivanov", PositionId = 9, HireDate = new DateTime(2013, 4, 16) },
            };

            return employees;
        }
    }
}
