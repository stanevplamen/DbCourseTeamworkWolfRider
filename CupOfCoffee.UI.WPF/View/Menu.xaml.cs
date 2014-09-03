namespace CupOfCoffee.UI.WPF.View
{
    using CupOfCoffee.Controllers.MySqlReports;
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
            this.Visibility = Visibility.Hidden;
            var mainWindow = StartWindow.GetMainWindow(this);
            mainWindow.ordersLoader.Visibility = Visibility.Visible;
        }

        private void btnFeedbackLoader_Click(object sender, RoutedEventArgs e)
        {
            //TODO: not implemented
        }

        private void btnSalaryCalculator_Click(object sender, RoutedEventArgs e)
        {
            //TODO: not implemented
            // Sample test to run Adobe Reader. Change the path after implementing logic
            var pathToPdf = @"..\..\..\Sample-Aggregated-Sales-Report.pdf";
            var pathToAcroRd32 = Environment.GetEnvironmentVariable("ProgramFiles") + @"\Adobe\Reader 11.0\Reader\AcroRd32.exe";
            var adobeInfo = new ProcessStartInfo(pathToAcroRd32, pathToPdf);
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
            //TODO: not implemented
        }

        private void btnTotalProfitCalculator_Click(object sender, RoutedEventArgs e)
        {
            //TODO: not implemented
        }
    }
}
