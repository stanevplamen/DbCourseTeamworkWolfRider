
namespace Handler.Excel
{
    using System;
    using System.Collections.Generic;
    using System.Data.OleDb;

    public class Program
    {
        public static void Main()
        {
            ParseExcelFile(@"..\..\..\", @"data\extracted\data.xlsx", "Products");
        }

        // TODO: Must add return value!
        //static public list<string> ParseExcelFile(string _path, string _fileName, string _requiredSheet)
        static public void ParseExcelFile(string _path, string _fileName, string _requiredSheet)
        {
            List<string> output = new List<string>();
            string requiredSheet = _requiredSheet + "$";
            OleDbConnectionStringBuilder connectionBuilder = new OleDbConnectionStringBuilder();
            connectionBuilder.Provider = "Microsoft.ACE.OLEDB.12.0";
            connectionBuilder.DataSource = _path + _fileName;
            connectionBuilder.Add("Extended Properties", "Excel 12.0;HDR=Yes;IMEX=2");
            OleDbConnection connectionExcel = new OleDbConnection(connectionBuilder.ConnectionString);

            try
            {
                connectionExcel.Open();
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Could not open excel file for parsing -> InvalidOperationException");
                //throw new InvalidOperationException("Could not open excel file for parsing -> InvalidOperationException");
            }
            catch (OleDbException)
            {
                Console.WriteLine("Could not open excel file for parsing -> OleDbException");
                //throw new InvalidOperationException("Could not open excel file for parsing -> OleDbException");
            }


            using (connectionExcel)
            {
                OleDbCommand command = new OleDbCommand("SELECT * FROM [" + requiredSheet + "]", connectionExcel);
                try
                {
                    OleDbDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        //TODO: This has to be changed according to the used Excel file. Must add return value!
                        output.Add(string.Format("Id: {0}, Product name: {1}, Quantity: {2}, Price: {3:C0}", data["Id"], data["Product Name"], data["Quantity"], data["Price"]));
                        Console.WriteLine("Id: {0}, Product name: {1}, Quantity: {2}, Price: {3:C0}", data["Id"], data["Product Name"], data["Quantity"], data["Price"]);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Could not parse excel file for parsing -> InvalidOperationException");
                    //throw new InvalidOperationException("Could not parse excel file for parsing -> InvalidOperationException");
                }
            }

            // return output
        }
    }
}
