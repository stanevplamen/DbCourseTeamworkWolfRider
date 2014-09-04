namespace CupOfCoffee.UI.WPF.View
{
    using System;
    using System.Windows;
    using System.Windows.Controls;

    using Microsoft.Win32;
    using Newtonsoft.Json;

    using CupOfCoffee.Controllers.XlmReportsParser;
    using CupOfCoffee.Data;

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
