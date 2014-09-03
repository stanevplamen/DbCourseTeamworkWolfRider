namespace CupOfCoffee.Controllers.SalaryReports
{
    public interface IEmployeeSalary
    {
        int EmployeeID { get; set; }
     
        string Name { get; set; }

        decimal BaseSalary { get; set; }

        decimal? ExperienceBonus { get; set; }

        decimal? FeedbackBonus { get; set; }

        decimal? TurnoverBonus { get; set; }

        decimal TotalSalary { get; set; }
    }
}
