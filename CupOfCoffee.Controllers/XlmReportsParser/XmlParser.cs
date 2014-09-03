using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CupOfCoffee.Models;
using CupOfCoffee.Data;
using Newtonsoft.Json;
using System.Data.Entity;
using System.Xml;
using System.Text;

namespace CupOfCoffee.Controllers.XlmReportsParser
{
    public class XmlParser
    {
        public static List<DailyWaitressReport> GetDailyTurnoverByWaitressReports()
        {
            CupOfCoffeeContext context = new CupOfCoffeeContext();
            var results = context.Orders
                .GroupBy(o => new { Date = DbFunctions.TruncateTime(o.OrderDate), Name = o.Employee.Name })
                .Select(gr => new DailyWaitressReport()
                {
                    Date = gr.Key.Date,
                    Name = gr.Key.Name,
                    Turnover = gr.Sum(g => g.OrderDetails.Sum(or => or.Quantity * or.Product.SellPrice))
                })
                .OrderBy(b => b.Date);

            return results.ToList();            
        }

        public static List<CustomerFeedback> GenerateFeedbacksFromXml(string path)
        {
            CupOfCoffeeContext context = new CupOfCoffeeContext();

            XmlDocument document = new XmlDocument();
            document.Load(path);
            XmlNode root = document.DocumentElement;

            List<CustomerFeedback> feedbacks = new List<CustomerFeedback>();

            foreach (XmlNode order in root.ChildNodes)
            {
                int orderId = int.Parse(order.Attributes["id"].Value);
                int employeeId = context.Orders.Where(o => o.Id == orderId).Select(e=>e.EmployeeId).FirstOrDefault();
                foreach (XmlNode feedback in order.ChildNodes)
                {
                    int evaluationValue = int.Parse(feedback.Attributes["evaluation"].Value);
                    CustomerEvaluation evaluation = (CustomerEvaluation)evaluationValue;
                    CustomerFeedback fb = new CustomerFeedback()
                    {
                        CustomerId = int.Parse(feedback.Attributes["customerId"].Value),
                        EmployeeId = employeeId,
                        OrderId = orderId,
                        Content = feedback.InnerText,
                        Evaluation = evaluation
                    };

                    feedbacks.Add(fb);
                }
            }

            return feedbacks;
        }

        public static void GenerateDailyTurnoverXmlReport(List<DailyWaitressReport> dailyReports, string path, string fileName)
        {
            string totalPath = path + fileName;
            Encoding encoding = Encoding.GetEncoding("windows-1251");

            using (XmlTextWriter writer = new XmlTextWriter(totalPath, encoding))
            {
                writer.Formatting = System.Xml.Formatting.Indented;

                writer.WriteStartDocument();
                writer.WriteStartElement("daily-reports");
                var lastDate = dailyReports[0].Date.Value;
                var currentDate = lastDate;
                writer.WriteStartElement("report");
                writer.WriteAttributeString("date", dailyReports[0].Date.Value.Date.ToShortDateString());
                foreach (var report in dailyReports)
                {
                    currentDate = report.Date.Value;
                    if (currentDate != lastDate)
                    {
                        writer.WriteEndElement();
                        writer.WriteStartElement("report");
                        writer.WriteAttributeString("date", report.Date.Value.Date.ToShortDateString());
                        WriteWaitress(writer, report);
                    }
                    else
                    {
                        WriteWaitress(writer, report);
                    }
                    lastDate = currentDate;
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        private static void WriteWaitress(XmlTextWriter writer, DailyWaitressReport report)
        {
            writer.WriteStartElement("waitress");
            writer.WriteAttributeString("name", report.Name);
            writer.WriteAttributeString("turnover", report.Turnover.ToString());
            writer.WriteEndElement();
        }
    }
}
