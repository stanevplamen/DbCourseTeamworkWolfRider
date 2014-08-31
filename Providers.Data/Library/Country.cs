using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providers.Data.Library
{
    public class Country
    {
        public ObjectId _id { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
    }
}
