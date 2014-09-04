namespace CupOfCoffee.UI.WPF.View
{
    using System;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Controls;

    using CupOfCoffee.Controllers.DataLoader;
    using CupOfCoffee.Controllers.FinalReport;
    using CupOfCoffee.Controllers.MySqlReports;
    using CupOfCoffee.Controllers.SalaryReports;
    using CupOfCoffee.Controllers.XlmReportsParser;
    using CupOfCoffee.Data;
    using CupOfCoffee.MySQL.Models;

    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : UserControl
    {
        public Menu()
        {
            InitializeComponent();
            DatabasePopulator.Seed();
        }

        private void btnDataLoader_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MongoDbExtractor.ExtractDataToSqlServer();
                MessageBox.Show("The orders were loaded successfully!",
                   "Loaded successfully",
                   MessageBoxButton.OK,
                   MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot load orders!",
                  "Loaded failed",
                  MessageBoxButton.OK,
                  MessageBoxImage.Error);
            }
        }

        private void btnOrderLoader_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            var mainWindow = StartWindow.GetMainWindow(this);
            mainWindow.ordersLoader.Visibility = Visibility.Visible;
        }

        private void btnFeedbackLoader_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            var mainWindow = StartWindow.GetMainWindow(this);
            mainWindow.feedbackLoader.Visibility = Visibility.Visible;
        }

        private void btnSalaryCalculator_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new CupOfCoffeeContext())
            {
                try
                {
                    var pdfFile = new PdfFile();
                    pdfFile.filename = "..\\..\\..\\PDFReport\\employee-sallaries.pdf";
                    pdfFile.title = "Report: Employees sallaries";
                    pdfFile.data = SalaryCalculator.Calculate(context);

                    PdfCreator.Create(pdfFile);

                    SalaryRecorder.Insert(pdfFile.data, context);

                    //var pathToAcroRd32 = Environment.GetEnvironmentVariable("ProgramFiles") + @"\Adobe\Reader 11.0\Reader\AcroRd32.exe";
                    //var adobeInfo = new ProcessStartInfo(pathToAcroRd32, pdfFile.filename);

                    MessageBox.Show("The report for employees was successfully generated!",
                        "Generated successfully",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);

                    Process.Start(pdfFile.filename);
                }
                catch (Exception)
                {
                    MessageBox.Show("Cannot generate the report for employees!",
                       "Generation failed",
                       MessageBoxButton.OK,
                       MessageBoxImage.Error);
                }
            }
        }

        private void btnProductIncomeCalculator_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string path = "..\\..\\..\\Json-Reports\\";
                CupOfCoffeeContext context = new CupOfCoffeeContext();
                var reports = ProductsReportsLoader.GetProductsSaleInfo(context);
                ProductsReportsLoader.GenerateJsonReports(reports, path);

                MySqlModel mySqlCOntext = new MySqlModel();
                ProductsReportsLoader.AddReports(reports, mySqlCOntext);

                MessageBox.Show("The products reports were successfully generated!",
                     "Generated successfully",
                     MessageBoxButton.OK,
                     MessageBoxImage.Information);

                Process.Start(path);
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot generate the products reports!",
                   "Generation failed",
                   MessageBoxButton.OK,
                   MessageBoxImage.Error);
            }           
        }

        private void btnSoldProductDisplayer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var path = "..\\..\\..\\XMLReport\\";
                var reports = XmlParser.GetDailyTurnoverByWaitressReports();
                XmlParser.GenerateDailyTurnoverXmlReport(reports, path, "DailyReports.xml");
                Process.Start(path);

                MessageBox.Show("The daily reports were successfully generated!",
                     "Generated successfully",
                     MessageBoxButton.OK,
                     MessageBoxImage.Information);

                Process.Start(path);
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot generate the daily reports!",
                    "Generation failed",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            } 
        }

        private void btnTotalProfitCalculator_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var path = "..\\..\\..\\FinalReport\\total-profit.xlsx";
                var mySqlCOntext = new MySqlModel();
                var products = ProductsReportsLoader.GetReportsFromMySql(mySqlCOntext);

                // TODO: Change it with entity framework
                var vendorsProduct = SqliteParser.GetVendorsProducts();
                ExcelGenerator.Generate(products, vendorsProduct, path);

                MessageBox.Show("The total profit report was successfully generated!",
                  "Generated successfully",
                  MessageBoxButton.OK,
                  MessageBoxImage.Information);

                Process.Start(path);
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot generate the total profit report!",
                  "Generation failed",
                  MessageBoxButton.OK,
                  MessageBoxImage.Error);
            }
            
        }
    }
}
