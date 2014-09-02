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
    /// Interaction logic for StartingControl.xaml
    /// </summary>
    public partial class StartingControl : UserControl
    {
        public StartingControl()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            var mainWindow = StartWindow.GetMainWindow(this);
            mainWindow.menu.Visibility = Visibility.Visible;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = StartWindow.GetMainWindow(this);
            mainWindow.Close();
        }
    }
}
