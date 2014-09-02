using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CupOfCoffee.UI.WPF.View
{
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
            // TODO: invoke method to load data, It must return true or false


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

        }

        private void btnSalaryCalculator_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnProductIncomeCalculator_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSoldProductDisplayer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnTotalProfitCalculator_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}
