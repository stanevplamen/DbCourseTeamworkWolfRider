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
            
        }

        private void btnFeedbackLoader_Click(object sender, RoutedEventArgs e)
        {
            //TODO: not implemented
        }

        private void btnSalaryCalculator_Click(object sender, RoutedEventArgs e)
        {
            var pdfFile = new PdfFile();
            pdfFile.filename = "..\\..\\..\\PDFReport\\employee-sallaries.pdf";
            pdfFile.title = "Report: Employees sallaries";
            pdfFile.data = SalaryCalculator.Calculate(new CupOfCoffeeContext());

            PdfCreator.Page_Load(pdfFile);

            // TODO: Total amount save it to montly salaries
            var pathToAcroRd32 = Environment.GetEnvironmentVariable("ProgramFiles") + @"\Adobe\Reader 11.0\Reader\AcroRd32.exe";
            var adobeInfo = new ProcessStartInfo(pathToAcroRd32, pdfFile.filename);
            Process.Start(adobeInfo);
        }

        private void btnProductIncomeCalculator_Click(object sender, RoutedEventArgs e)
        {
            string path = "..\\..\\..\\JSONReports\\";
            CupOfCoffeeContext context = new CupOfCoffeeContext();
            var reports = ProductsReportsLoader.GetProductsSaleInfo(context);
            ProductsReportsLoader.GenerateJsonReports(reports, path);

            MySqlModel mySqlCOntext = new MySqlModel();
            ProductsReportsLoader.AddReports(reports, mySqlCOntext);
            Process.Start(path);
        }

        private void btnSoldProductDisplayer_Click(object sender, RoutedEventArgs e)
        {
            var reports = XmlParser.GetDailyTurnoverByWaitressReports();
            XmlParser.GenerateDailyTurnoverXmlReport(reports, "..\\..\\", "DailyReports.xml");
        }

        private void btnTotalProfitCalculator_Click(object sender, RoutedEventArgs e)
        {
            //TODO: not implemented
        }
    }
}
