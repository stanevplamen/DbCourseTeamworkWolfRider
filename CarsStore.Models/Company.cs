using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsStore.Models
{
    public class Company
    {
        private ICollection<Car> cars;

        public Company()
        {
            this.cars = new HashSet<Car>();
        }

        // mongo db id
        public ObjectId _id { get; set; }

        // ms server id
        [Key]
        public int? CompanyId { get; set; }

        // connection to countrues
        //[ForeignKey("Country")]
        public int CountryId { get; set; }

        public string Model { get; set; }

        public int Employees { get; set; }

        public decimal Income { get; set; }

        public virtual ICollection<Car> Cars
        {
            get { return this.cars; }
            set { this.cars = value; }
        }
    }
}
