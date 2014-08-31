using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsStore.Models
{
    public class Country
    {
        private ICollection<Company> companies;

        public Country()
        {
            this.companies = new HashSet<Company>();
        }

        // mongo db id
        public ObjectId _id { get; set; }

        // ms server id
        [Key]
        public int? CountryId { get; set; }

        public string Name { get; set; }

        public int Population { get; set; }

        public virtual ICollection<Company> Companies
        {
            get { return this.companies; }
            set { this.companies = value; }
        }
    }
}