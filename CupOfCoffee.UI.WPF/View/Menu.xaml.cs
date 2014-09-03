namespace CupOfCoffee.UI.WPF.View
{
    using CupOfCoffee.Controllers.XlmReportsParser;
    using CupOfCoffee.Controllers.MySqlReports;
    using CupOfCoffee.Controllers.SalaryReports;
    using CupOfCoffee.Data;
    using CupOfCoffee.MySQL.Models;
    using System;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Controls;
    using Newtonsoft.Json;

    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : UserControl
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnDataLoader_Click(object sender, RoutedEventArgs e)
        {
            //TODO: not implemented
            if (true)
            {
                MessageBox.Show("The orders were loaded successfully!",
                    "Loaded successfully",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            else
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
            string pathToFile = string.Empty;
            CupOfCoffeeContext context = new CupOfCoffeeContext();
            var feedbacks = XmlParser.GenerateFeedbacksFromXml(pathToFile);
            foreach (var feedback in feedbacks)
            {
                context.CustomerFeedbacks.Add(feedback);
            }
            context.SaveChanges();

            foreach (var feedback in feedbacks)
            {
                string feedbackAsJson = JsonConvert.SerializeObject(feedback);
            }
        }

        private void btnSalaryCalculator_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new CupOfCoffeeContext())
            {
                var pdfFile = new PdfFile();
                pdfFile.filename = "..\\..\\..\\PDFReport\\employee-sallaries.pdf";
                pdfFile.title = "Report: Employees sallaries";
                pdfFile.data = SalaryCalculator.Calculate(context);

                PdfCreator.Create(pdfFile);

                SalaryRecorder.Insert(pdfFile.data, context);

                var pathToAcroRd32 = Environment.GetEnvironmentVariable("ProgramFiles") + @"\Adobe\Reader 11.0\Reader\AcroRd32.exe";
                var adobeInfo = new ProcessStartInfo(pathToAcroRd32, pdfFile.filename);
                Process.Start(adobeInfo);
            }
        }

        private void btnProductIncomeCalculator_Click(object sender, RoutedEventArgs e)
        {
            string path = "..\\..\\..\\Json-Reports\\";
            CupOfCoffeeContext context = new CupOfCoffeeContext();
            var reports = ProductsReportsLoader.GetProductsSaleInfo(context);
            ProductsReportsLoader.GenerateJsonReports(reports, path);

            MySqlModel mySqlCOntext = new MySqlModel();
            ProductsReportsLoader.AddReports(reports, mySqlCOntext);
            Process.Start(path);
        }

        private void btnSoldProductDisplayer_Click(object sender, RoutedEventArgs e)
        {
            var path = "..\\..\\..\\XMLReport\\";
            var reports = XmlParser.GetDailyTurnoverByWaitressReports();
            XmlParser.GenerateDailyTurnoverXmlReport(reports, path, "DailyReports.xml");
            Process.Start(path);
        }

        private void btnTotalProfitCalculator_Click(object sender, RoutedEventArgs e)
        {
            //TODO: not implemented
        }
    }
}
