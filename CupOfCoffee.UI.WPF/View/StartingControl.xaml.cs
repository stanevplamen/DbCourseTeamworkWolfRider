namespace CupOfCoffee.UI.WPF.View
{
    using System.Windows;
    using System.Windows.Controls;

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
