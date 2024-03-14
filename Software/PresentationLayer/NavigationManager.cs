using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PresentationLayer
{
    public static class NavigationManager
    {
        public static void Navigate(UserControl userControl)
        {
            AppWindow appWindow = Application.Current.MainWindow as AppWindow;

            if(appWindow != null) 
            {
                appWindow.mainContent.Content = userControl;
            }
            
        }
        public static void Navigate(Window window)
        {
            window.Show();
        }
    }
}
