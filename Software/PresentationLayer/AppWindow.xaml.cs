using BusinessLayer;
using DataAccessLayer;
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
using System.Windows.Shapes;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for AppWindow.xaml
    /// </summary>
    public partial class AppWindow : Window
    {
        private RoomService roomService;
        public AppWindow()
        {
            roomService = new RoomService();
            InitializeComponent();
            PreloadData();
        }

        private void btnRoom_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.Navigate(new RoomAdministrationUserControl());
            
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.Navigate(new RegistrationUserControl());

        }


        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.ShowDialog();
        }

        private void btnStartPage_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.Navigate(new AdminUserControl());
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            NavigationManager.Navigate(new AdminUserControl());
        }
        private void PreloadData()
        {
            var rooms = roomService.GetAllRooms();
            var roomAdminControl = new RoomAdministrationUserControl();
            roomAdminControl.SetRoomData(rooms);
            NavigationManager.Navigate(roomAdminControl);
        }

    }
}
