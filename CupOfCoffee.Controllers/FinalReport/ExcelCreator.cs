namespace CupOfCoffee.Controllers.FinalReport
{
    using System.Collections.Generic;

    using GemBox.Spreadsheet;

    using CupOfCoffee.SQLite.Data.Database;
    using CupOfCoffee.MySQL.Models;

    public static class ExcelGenerator
    {
        public static void Generate(IList<ProductReport> productReports, Dictionary<string, VendorsProduct> vendorsProducts, string fullPath)
        {
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
            var ef = new ExcelFile();
            var ws = ef.Worksheets.Add("Total Profit");

            ws.Cells[0, 0].Value = "Product Name";
            ws.Cells[0, 1].Value = "Base Price";
            ws.Cells[0, 2].Value = "Quantity";
            ws.Cells[0, 3].Value = "Income";
            ws.Cells[0, 4].Value = "Profit";

            for (int i = 1; i < productReports.Count; i++)
            {
                ws.Cells[i, 0].Value = productReports[i].ProductName;
                ws.Cells[i, 1].Value = vendorsProducts[productReports[i].ProductName].BasePrice;
                ws.Cells[i, 2].Value = productReports[i].TotalQuantitySold;
                ws.Cells[i, 3].Value = productReports[i].TotalIncome;
                ws.Cells[i, 4].Value =
                    productReports[i].TotalIncome - vendorsProducts[productReports[i].ProductName].BasePrice * productReports[i].TotalQuantitySold;
            }

            ef.Save(fullPath);
        }
    }
}
