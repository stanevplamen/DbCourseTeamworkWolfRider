namespace CupOfCoffee.Controllers.SalaryReports
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CupOfCoffee.Data;

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
                ExperienceBonus = ((Nullable<decimal>)(DateTime.Now.Year - e.HireDate.Year) ?? 0) * 20,
                FeedbackBonus = ((Nullable<decimal>)e.CustomerFeedbacks.Where(cf => cf.Order.OrderDate > lastMonthDate).Average(cf => (decimal)cf.Evaluation) ?? 0) * 20,
                TurnoverBonus = ((Nullable<decimal>)e.Orders.Where(
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
                        )
                    ?? 0) * 0.1m
            });

            salaries = results.ToList();

            foreach (var salary in salaries)
            {
                salary.TotalSalary = salary.BaseSalary + (decimal)salary.ExperienceBonus + (decimal)salary.FeedbackBonus + (decimal)salary.TurnoverBonus;
            }

            return salaries;
        }
    }
}
