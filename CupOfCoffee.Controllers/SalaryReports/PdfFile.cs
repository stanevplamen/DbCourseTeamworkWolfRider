namespace CupOfCoffee.Controllers.SalaryReports
{
    using System.Collections.Generic;

    public struct PdfFile
    {
        public string filename;
        public string title;
        public IList<EmployeeSalary> data;
        public int total;
    }
}
