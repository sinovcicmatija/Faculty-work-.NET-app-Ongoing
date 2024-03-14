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
using System.Windows.Threading;

namespace PresentationLayer.RoomGuestScreen
{
    /// <summary>
    /// Interaction logic for MainRoomScreenView.xaml
    /// </summary>
    public partial class MainRoomScreenView : Window
    {
        private DispatcherTimer timer;
        private GuestServices guestServices;
        private Room selectedRoom;

        public MainRoomScreenView(Room room)
        {
            selectedRoom = room;
            guestServices = new GuestServices();
            InitializeComponent();


            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();

            LoadGuestView();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            txtDateTime.Text = DateTime.Now.ToString();
        }

        private void LoadGuestView()
        {
            txtGuestName.Text = guestServices.GetGuestByRoom(selectedRoom).Name.ToString();
            txtRoomNumber.Text = selectedRoom.IdRoom.ToString();
        }

        private void btnDoNotDisturb_Click(object sender, RoutedEventArgs e)
        {
            btnDoNotDisturb.Background = new SolidColorBrush(Colors.Red);


        }

        private void btnCleaning_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnReception_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
