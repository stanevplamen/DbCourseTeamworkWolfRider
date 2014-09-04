namespace CupOfCoffee.UI.WPF
{
    using System.Windows;

    public static class StartWindow
    {
        public static MainWindow GetMainWindow(DependencyObject dependancyObject)
        {
            MainWindow mainWindow = null;
            var parentWindow = Window.GetWindow(dependancyObject);

            if (parentWindow != null)
            {
                mainWindow = parentWindow as MainWindow;

                if (mainWindow != null)
                {
                    return mainWindow;
                }
            }

            return null;
        }
    }
}
