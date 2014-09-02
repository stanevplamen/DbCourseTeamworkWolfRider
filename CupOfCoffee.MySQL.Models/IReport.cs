namespace CupOfCoffee.MySQL.Models
{
    using System;

    public interface IReport
    {
        string ProductCategory { get; set; }
        int ProductID { get; set; }
        string ProductName { get; set; }
        int ReportID { get; set; }
        decimal TotalIncome { get; set; }
        int TotalQuantitySold { get; set; }
    }
}
