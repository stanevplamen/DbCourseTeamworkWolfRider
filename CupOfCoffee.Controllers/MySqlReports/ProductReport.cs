using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CupOfCoffee.Controllers.MySqlReports
{
    public class ProductReport : IProductReport
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal TotalIncome { get; set; }
        public int TotalQuantitySold { get; set; }
    }
}
