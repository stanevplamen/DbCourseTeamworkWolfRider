namespace CupOfCoffee.Controllers.SalaryReports
{
    public class EmployeeSalary : IEmployeeSalary
    {
        public string Name { get; set; }

        public decimal BaseSalary { get; set; }

        public decimal ExperienceBonus { get; set; }

        public decimal FeedbackBonus { get; set; }

        public decimal TurnoverBonus { get; set; }

        public decimal TotalSalary { get; set; }
    }
}
