using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RidersCoffees.Models
{
    public class CoffeePlace
    {
        private ICollection<Employee> employees;
        private ICollection<Product> products;

        public CoffeePlace()
        {
            this.employees = new HashSet<Employee>();
            this.products = new HashSet<Product>();
        }

        // mongo db id
        public ObjectId _id { get; set; }

        // ms server id
        [Key]
        public int? CoffeePlaceId { get; set; }

        public string Name { get; set; }

        public int SeatsNumber { get; set; }

        public virtual ICollection<Employee> Employees
        {
            get { return this.employees; }
            set { this.employees = value; }
        }

        public virtual ICollection<Product> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }
    }
}
