﻿namespace CupOfCoffee.Controllers.SalaryReports
{
    using CupOfCoffee.Data;
    using CupOfCoffee.Models;
    using System;
    using System.Collections.Generic;

    public static class SalaryRecorder
    {
        public static void Insert(IList<EmployeeSalary> salaries, CupOfCoffeeContext context)
        {
            foreach (var salary in salaries)
            {
                context.MonthlySalaries.Add(new MonthlySalary
                {
                    EmployeeId = salary.EmployeeID,
                    Date = DateTime.Now,
                    Amount = salary.TotalSalary
                });
            }

            context.SaveChanges();
        }
    }
}
