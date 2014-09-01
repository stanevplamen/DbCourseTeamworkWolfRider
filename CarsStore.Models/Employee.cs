using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RidersCoffees.Models
{
    public class Employee
    {
        public Employee()
        {
        }

        // mongo db id
        public ObjectId _id { get; set; }

        // ms server id
        [Key]
        public int? EmployeeId { get; set; }

        // connection to coffee places
        //[ForeignKey("CoffeePlace")]
        public int CoffeePlaceId { get; set; }

        public string CoffeePlaceMongoId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Position { get; set; }

        public int Years { get; set; }

        public decimal Salary { get; set; }

    }
}
