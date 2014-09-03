using System;
namespace CupOfCoffee.Controllers.MySqlReports
{
    public interface IProductReport
    {
        string Category { get; set; }
        string Name { get; set; }
        int ProductID { get; set; }
        decimal TotalIncome { get; set; }
        int TotalQuantitySold { get; set; }
    }
}
