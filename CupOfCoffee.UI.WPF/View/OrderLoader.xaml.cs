
using Providers.Controllers.ReportLoader;
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
    /// Interaction logic for OrdersLoader.xaml
    /// </summary>
    public partial class OrdersLoader : UserControl
    {
        private const string defaultFolder = "ExcelReports";
            
        private Microsoft.Win32.OpenFileDialog dlg;
        private string filePath = string.Empty;
        private string fileName = string.Empty;


        public OrdersLoader()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            this.dlg = new Microsoft.Win32.OpenFileDialog();
            this.dlg.DefaultExt = "zip";
            this.dlg.Filter = "ZIP Files (*.zip)|*.zip";

            Nullable<bool> result = this.dlg.ShowDialog();

            if (result == true)
            {
                this.fileName = this.dlg.SafeFileName;
                this.filePath = this.dlg.FileName.Replace(fileName, string.Empty);
            }
        }

        private void btnExtract_Click(object sender, RoutedEventArgs e)
        {
            var result = Archive.Extract(this.filePath, this.fileName, defaultFolder);

            if (result)
            {
                MessageBox.Show("Extracted successfully the zip archive!",
                    "Extracted successfully",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Cannot extract the file!",
                   "Extracted failed",
                   MessageBoxButton.OK,
                   MessageBoxImage.Error);
            }
        }

        private void btnOrderLoader_Click(object sender, RoutedEventArgs e)
        {
            var reportsFolder = this.filePath + defaultFolder;
            var fileExtension = "*.xls";
            var files = new List<string>();

            ReportFinder.TraverseDirectory(reportsFolder, fileExtension, files);

            var productsSheet = "Products";
            var orderSheet = "Order";

            foreach (var file in files)
            {
                var result = ExcelParser.Parse(file, productsSheet, orderSheet);

                if (result)
                {
                    MessageBox.Show("Extracted successfully the zip archive!",
                        "Extracted successfully",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Cannot extract the file!",
                       "Extracted failed",
                       MessageBoxButton.OK,
                       MessageBoxImage.Error);
                }
            }
        }
    }
}
