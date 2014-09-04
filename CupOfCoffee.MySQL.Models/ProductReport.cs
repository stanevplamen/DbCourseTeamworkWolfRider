namespace CupOfCoffee.MySQL.Models
{
    public class ProductReport : IProductReport
    {
        public int ReportID { get; set; }

        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public string ProductCategory { get; set; }

        public decimal? TotalIncome { get; set; }

        public int? TotalQuantitySold { get; set; }
    }
}
