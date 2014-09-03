using CupOfCoffee.Controllers.XlmReportsParser;
using CupOfCoffee.Data;
using Microsoft.Win32;
using Newtonsoft.Json;
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
    /// Interaction logic for FeedbackLoader.xaml
    /// </summary>
    public partial class FeedbackLoader : UserControl
    {
        private OpenFileDialog dlg;
        private string filePath = string.Empty;

        public FeedbackLoader()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            this.dlg = new OpenFileDialog();
            this.dlg.DefaultExt = "xml";
            this.dlg.Filter = "XML Files (*.xml)|*.xml";

            Nullable<bool> result = this.dlg.ShowDialog();

            if (result == true)
            {
                this.filePath = this.dlg.FileName;
                this.txtPath.Text = this.dlg.FileName;
            }
        }

        private void btnFeedbackLoader_Click(object sender, RoutedEventArgs e)
        {
            if (this.filePath != string.Empty)
            {
                using (var context = new CupOfCoffeeContext())
                {
                    try
                    {
                        var feedbacks = XmlParser.GenerateFeedbacksFromXml(this.filePath);
                        foreach (var feedback in feedbacks)
                        {
                            context.CustomerFeedbacks.Add(feedback);
                        }

                        context.SaveChanges();


                        foreach (var feedback in feedbacks)
                        {
                            string feedbackAsJson = JsonConvert.SerializeObject(feedback);
                            // TODO: Add it to MongoDB
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Cannot load the xml! Please, make sure that the data in it is correct!",
                          "Error",
                           MessageBoxButton.OK,
                           MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("There is no xml file chosen!",
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
            this.txtPath.Text = string.Empty;
        }
    }
}
