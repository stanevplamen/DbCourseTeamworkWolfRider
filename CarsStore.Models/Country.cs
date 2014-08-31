using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsStore.Models
{
    public class Country
    {
        // mongo db id
        public ObjectId _id { get; set; }

        // ms server id
        public int? CountryId { get; set; }

        public string Name { get; set; }

        public int Population { get; set; }
    }
}