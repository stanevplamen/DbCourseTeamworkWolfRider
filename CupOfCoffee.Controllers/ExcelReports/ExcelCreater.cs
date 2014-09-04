namespace CupOfCoffee.Controllers.ExcelReports
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.Office.Interop;
    using Microsoft.Office.Interop.Excel;

    using System.Data.OleDb;

    public static class ExelCreator
    {
        public static void Generate(IList<AverageDriverSalary> averageDriverSalary, IList<AverageTravelledDistance> averageTravelledDistance, string path)
        {
            CreateExcelFile(path);
            string connectionString = BuildConnectionString(path);
            OleDbConnection connExcel = new OleDbConnection(connectionString);
            using (connExcel)
            {
                connExcel.Open();
                GenerateAverageDriverSalary(averageDriverSalary, connExcel);
                GenerateAverageTravelledDistance(averageTravelledDistance, connExcel);
            }
        }

        private static void GenerateSchema(string tableName, ICollection<string> columnsNames, OleDbConnection connExcel)
        {
            var columnsWithAddedType = columnsNames.Select(x => "[" + x + "]" + " String");
            var formatedColumnNames = string.Join(", ", columnsWithAddedType);
            OleDbCommand tableCreationCommand = new OleDbCommand("CREATE TABLE [" + tableName + "](" + formatedColumnNames + ");", connExcel);
            tableCreationCommand.ExecuteNonQuery();
        }

        private static void CreateExcelFile(string filePath)
        {
            var app = new Microsoft.Office.Interop.Excel.Application();
            app.Visible = false;
            var wb = app.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            var sheets = app.Worksheets;
            wb.Sheets.Add(Type.Missing, Type.Missing, 1, Type.Missing);
            var newSheet = (Worksheet)sheets.get_Item(1);
            wb.SaveAs(filePath);
            wb.Close();
        }

        private static void GenerateAverageDriverSalary(IList<AverageDriverSalary> averageDriverSalary, OleDbConnection connExcel)
        {
            var columnsNames = new List<string>() { "Driver first name", "Driver last name", "Average salary" };
            this.GenerateSchema(AVERAGE_DRIVER_SALARY_TABLE_NAME, columnsNames, connExcel);
            var salaryReportColumns = columnsNames.Select(x => "[" + x + "]");
            var formatedSalaryReportColumns = string.Join(", ", salaryReportColumns);
            foreach (var salaryReport in averageDriverSalary)
            {
                OleDbCommand insertingAverageSalaryReportCommand = new OleDbCommand(@"INSERT INTO [" + AVERAGE_DRIVER_SALARY_TABLE_NAME + "$] (" + formatedSalaryReportColumns + ") VALUES('" + salaryReport.DriverFirstName + "', '" + salaryReport.AverageSalary + "')", connExcel);
                insertingAverageSalaryReportCommand.ExecuteNonQuery();
            }
        }

        private static void GenerateAverageTravelledDistance(IList<AverageTravelledDistance> averageTravelledDistance, OleDbConnection connExcel)
        {
            var columnsNames = new List<string>() { "Vehicle model", "Manufacturer", "Average travelled distance" };
            this.GenerateSchema(AVERAGE_TRAVELLED_DISTANCE_TABLE_NAME, columnsNames, connExcel);
            var travelReportColumns = columnsNames.Select(x => "[" + x + "]");
            var formatedTravelReportColumns = string.Join(", ", travelReportColumns);
            foreach (var distanceReport in averageTravelledDistance)
            {
                OleDbCommand insertingAverageSalaryReportCommand = new OleDbCommand(@"INSERT INTO [" + AVERAGE_TRAVELLED_DISTANCE_TABLE_NAME + "$] (" + formatedTravelReportColumns + ") VALUES('" + distanceReport.VehicleModel + "', '" + distanceReport.VehicleManufacturer + "', '" + distanceReport.AverageDistance + "')", connExcel);
                insertingAverageSalaryReportCommand.ExecuteNonQuery();
            }
        }

        private static string BuildConnectionString(string filePath)
        {
            Dictionary<string, string> props = new Dictionary<string, string>();
            props["Provider"] = "Microsoft.Jet.OLEDB.4.0";
            props["Extended Properties"] = "Excel 8.0;HDR=Yes";
            props["Data Source"] = filePath;
            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<string, string> prop in props)
            {
                sb.Append(prop.Key);
                sb.Append('=');
                sb.Append(prop.Value);
                sb.Append(';');
            }

            return sb.ToString();
        }
    }
}
