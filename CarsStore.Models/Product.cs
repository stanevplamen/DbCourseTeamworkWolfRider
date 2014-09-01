using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RidersCoffees.Models
{
    public class Product
    {
        public Product()
        {
        }

        // mongo db id
        public ObjectId _id { get; set; }

        // ms server id
        [Key]
        public int? ProductId { get; set; }

        // connection to coffee places
        //[ForeignKey("CoffeePlace")]
        public int CoffeePlaceId { get; set; }

        public string CoffeePlaceMongoId { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public decimal Price { get; set; }
    }
}
