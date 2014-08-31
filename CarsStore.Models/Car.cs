using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsStore.Models
{
    public class Car
    {
        public Car()
        {
        }

        // mongo db id
        public ObjectId _id { get; set; }

        // ms server id
        [Key]
        public int? CarId { get; set; }

        // connection to companies
        //[ForeignKey("Company")]
        public int CompanyId { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public decimal Price { get; set; }
    }
}
