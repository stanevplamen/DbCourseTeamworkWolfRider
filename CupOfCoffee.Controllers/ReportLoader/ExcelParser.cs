namespace CupOfCoffee.Controllers.ReportLoader
{
    using System;
    using System.Data.OleDb;

    using CupOfCoffee.Data;
    using CupOfCoffee.Models;

    public static class ExcelParser
    {
        static public bool Parse(string _filePath, string _productsSheet, string _orderSheet)
        {
            var reportSheet = _productsSheet + "$";
            var reportDetail = _orderSheet + "$";

            var connectionBuilder = new OleDbConnectionStringBuilder();
            connectionBuilder.Provider = "Microsoft.Jet.OLEDB.4.0";
            connectionBuilder.DataSource = _filePath;
            connectionBuilder.Add("Extended Properties", "Excel 8.0;HDR=Yes");
            var connectionExcel = new OleDbConnection(connectionBuilder.ConnectionString);

            try
            {
                connectionExcel.Open();
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Could not open excel file for parsing -> InvalidOperationException");
                return false;
                //throw new InvalidOperationException("Could not open excel file for parsing -> InvalidOperationException");
            }
            catch (OleDbException)
            {
                Console.WriteLine("Could not open excel file for parsing -> OleDbException");
                return false;
                //throw new InvalidOperationException("Could not open excel file for parsing -> OleDbException");
            }

            using (connectionExcel)
            {
                var query = "SELECT * FROM [{0}]";
                var details = new OleDbCommand(string.Format(query, reportDetail), connectionExcel);
                var orderId = 0;

                using (var sqlConnection = new CupOfCoffeeContext())
                {
                    var employeeId = 0;
                    int? custemerId = null;
                    var date = new DateTime();


                    using (var data = details.ExecuteReader())
                    {
                        data.Read();

                        employeeId = Convert.ToInt32(data["EmployeeId"]);

                        if (data["CustomerId"] != null)
                        {
                            custemerId = Convert.ToInt32(data["CustomerId"]);
                        }

                        date = DateTime.Parse((string)data["Date"]);
                    }

                    var order = sqlConnection.Orders.Add(
                        new Order()
                        {
                            EmployeeId = employeeId,
                            CustomerId = custemerId,
                            OrderDate = date
                        }
                    );
                    sqlConnection.SaveChanges();

                    orderId = order.Id;

                    var products = new OleDbCommand(string.Format(query, reportSheet), connectionExcel);

                    try
                    {
                        using (var data = products.ExecuteReader())
                        {
                            while (data.Read())
                            {
                                var productId = Convert.ToInt32(data["ProductId"]);
                                var quantity = Convert.ToInt32(data["Quantity"]);
                                var happyHour = Convert.ToBoolean(data["HappyHour"]);

                                sqlConnection.OrderDetails.Add(
                                    new OrderDetail()
                                    {
                                        OrderId = orderId,
                                        ProductId = productId,
                                        Quantity = quantity,
                                        HappyHour = happyHour
                                    }
                                );
                            }
                        }

                        sqlConnection.SaveChanges();
                        return true;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Could not parse excel file for parsing -> InvalidOperationException");
                        return false;
                        //throw new InvalidOperationException("Could not parse excel file for parsing -> InvalidOperationException");
                    }
                }
            }
        }
    }
}
