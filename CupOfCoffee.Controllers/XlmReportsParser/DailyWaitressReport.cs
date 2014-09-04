namespace CupOfCoffee.Controllers.XlmReportsParser
{
    using System;

    public class DailyWaitressReport
    {
        public DateTime? Date { get; set; }

        public string Name { get; set; }

        public decimal Turnover { get; set; }
    }
}
