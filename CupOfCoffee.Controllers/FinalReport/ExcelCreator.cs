namespace CupOfCoffee.Controllers.FinalReport
{
    using System.Collections.Generic;

    using CupOfCoffee.MySQL.Models;

    using System.Drawing;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using DocumentFormat.OpenXml;
    using DocumentFormat.OpenXml.Spreadsheet;
    using SpreadsheetLight;
    using System.IO;
    using OfficeOpenXml;
    using OfficeOpenXml.Style;
    using CupOfCoffee.SQLite.Data.DatabaseSqlite;

    public static class ExcelGenerator
    {
        public static void Generate(IList<ProductReport> productReports, Dictionary<string, VendorsProduct> vendorsProducts, string fullPath)
        {
            var file = new FileInfo(fullPath);

            if (file.Exists)
            {
                File.Delete(fullPath);
            }

            file = new FileInfo(fullPath);

            using (var package = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Profit");

                worksheet.Row(1).Height = 20;
                worksheet.Row(2).Height = 18;

                worksheet.Cells[1, 1].Value = "Total Profit";
                var headerRange = worksheet.Cells[1, 1, 1, 5];
                headerRange.Style.Font.Bold = true;
                headerRange.Style.Font.Size = 16;
                headerRange.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                worksheet.Cells[2, 1].Value = "Product Name";
                worksheet.Cells[2, 2].Value = "Base Price";
                worksheet.Cells[2, 3].Value = "Quantity";
                worksheet.Cells[2, 4].Value = "Income";
                worksheet.Cells[2, 5].Value = "Profit";

                var rowNumber = 3;

                foreach (var product in productReports)
                {
                    worksheet.Cells[rowNumber, 1].Value = productReports[rowNumber - 3].ProductName;
                    worksheet.Cells[rowNumber, 2].Value = vendorsProducts[productReports[rowNumber - 3].ProductName].BasePrice / 100.0m;
                    worksheet.Cells[rowNumber, 3].Value = productReports[rowNumber - 3].TotalQuantitySold;
                    worksheet.Cells[rowNumber, 4].Value = productReports[rowNumber - 3].TotalIncome;
                    worksheet.Cells[rowNumber, 5].Value =
                        productReports[rowNumber - 3].TotalIncome - 
                        (vendorsProducts[productReports[rowNumber - 3].ProductName].BasePrice / 100.0m) * 
                        productReports[rowNumber - 3].TotalQuantitySold;

                    rowNumber++;
                }

                worksheet.Column(1).AutoFit();
                worksheet.Column(2).AutoFit();
                worksheet.Column(3).AutoFit();
                worksheet.Column(4).AutoFit();
                worksheet.Column(5).AutoFit();

                package.Save();
            }
        }
    }
}
