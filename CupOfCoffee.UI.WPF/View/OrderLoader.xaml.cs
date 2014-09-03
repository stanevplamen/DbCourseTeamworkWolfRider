namespace CupOfCoffee.UI.WPF.View
{
    using CupOfCoffee.Controllers.ReportLoader;
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;

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
                this.txtPath.Text = this.dlg.FileName;
            }
        }

        private void btnExtract_Click(object sender, RoutedEventArgs e)
        {
            if (this.fileName != string.Empty && this.filePath != string.Empty)
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
            else
            {
                MessageBox.Show("There is no zip archive chosen!",
                     "Warning",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }

        private void btnOrderLoader_Click(object sender, RoutedEventArgs e)
        {
            if (this.fileName != string.Empty && this.filePath != string.Empty)
            {
                var reportsFolder = this.filePath + defaultFolder;
                var fileExtension = "*.xls";
                var files = new List<string>();

                ReportFinder.TraverseDirectory(reportsFolder, fileExtension, files);

                var productsSheet = "Products";
                var orderSheet = "Order";
                var loadedComplete = true;
                
                foreach (var file in files)
                {
                    var result = ExcelParser.Parse(file, productsSheet, orderSheet);

                    if (!result)
                    {
                        loadedComplete = false;
                    }
                }

                if (loadedComplete)
                {
                    MessageBox.Show("Successfully loaded the orders!",
                        "Loaded successfully",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("One or more orders cannot be loaded!",
                       "Loaded failed",
                       MessageBoxButton.OK,
                       MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("There is no zip archive chosen!",
                       "Warning",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.ClearContent();

            this.Visibility = Visibility.Hidden;
            var mainWindow = StartWindow.GetMainWindow(this);
            mainWindow.menu.Visibility = Visibility.Visible;
        }
        
        private void ClearContent()
        {
            this.dlg = null;
            this.filePath = string.Empty;
            this.fileName = string.Empty;
            this.txtPath.Text = string.Empty;
        }
    }
}
