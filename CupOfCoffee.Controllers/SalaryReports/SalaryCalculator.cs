namespace CupOfCoffee.Controllers.SalaryReports
{
    using CupOfCoffee.Data;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SalaryCalculator
    {

        public static IList<EmployeeSalary> Calculate(CupOfCoffeeContext context)
        {
            var salaries = new List<EmployeeSalary>();

            var currentDate = DateTime.Now;
            var lastMonthDate = currentDate.AddMonths(-1);

            var results = context.Employees.Select(e => new EmployeeSalary()
            {
                EmployeeID = e.Id,
                Name = e.Name,
                BaseSalary = e.Position.BaseSalary,
                ExperienceBonus = (e.HireDate.Year - DateTime.Now.Year) * 20,
                FeedbackBonus = e.CustomerFeedbacks.Where(cf => cf.Order.OrderDate > lastMonthDate).Average(cf => (decimal)cf.Evaluation) * 20,
                TurnoverBonus = e.Orders.Where(
                        o => o.OrderDate > lastMonthDate
                    )
                        .Sum(
                            o => o.OrderDetails.Sum(
                                od => od.Quantity * (
                                    od.Product.SellPrice - (
                                    od.HappyHour ? 0 : od.Product.SellPrice * 0.25m
                                    ) - (
                                    od.Product.SellPrice * (
                                    od.Order.Customer.CustomerStatus.Discount / 100
                                    )
                                    )
                                )
                            )
                        ) * 0.1m
            });

            salaries = results.ToList();

            foreach (var salary in salaries)
            {
                salary.TotalSalary = salary.BaseSalary + salary.ExperienceBonus + salary.FeedbackBonus + salary.TurnoverBonus;
            }

            return salaries;
        }
    }
}
