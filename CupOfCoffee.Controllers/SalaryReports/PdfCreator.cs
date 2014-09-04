namespace CupOfCoffee.Controllers.SalaryReports
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    using iTextSharp.text;
    using iTextSharp.text.html.simpleparser;
    using iTextSharp.text.pdf;

    public static class PdfCreator
    {
        public static void Create(PdfFile content)
        {
            var document = new Document();

            PdfWriter.GetInstance(document, new FileStream(content.filename, FileMode.Create));
            document.Open();

            var builder = new StringBuilder();

            builder.Append("<table border='1'><head>");
            builder.Append("<tr><th colspan=\"4\">" + content.title + "</th></tr></thead></table>");

            foreach (var employee in content.data)
            {
                builder.Append("<table  border='1'><tr><td colspan=\"4\">Name: " + employee.Name + "</td></tr>");
                builder.Append("<tr><td>Base Salary</td><td>Experience Bonus</td><td>Feedback Bonus</td><td>Turnover Bonus</td>");
                builder.Append("<tr>");
                builder.Append(string.Format("<td>{0:0.00}$</td>", employee.BaseSalary));
                builder.Append(string.Format("<td>{0:0.00}$</td>", employee.ExperienceBonus));
                builder.Append(string.Format("<td>{0:0.00}$</td>", employee.FeedbackBonus));
                builder.Append(string.Format("<td>{0:0.00}$</td>", employee.TurnoverBonus));
                builder.Append("</tr>");
                builder.Append(string.Format("<tr><td colspan=\"4\">Total Salary: {0:0.00}$</td></tr></table><br>", employee.TotalSalary));
            }

            var htmlText = builder.ToString();

            var htmlarraylist = HTMLWorker.ParseToList(new StringReader(htmlText), null);
            
            for (int k = 0; k < htmlarraylist.Count; k++)
            {
                document.Add((IElement)htmlarraylist[k]);
            }

            document.Close();
        }
    }
}
