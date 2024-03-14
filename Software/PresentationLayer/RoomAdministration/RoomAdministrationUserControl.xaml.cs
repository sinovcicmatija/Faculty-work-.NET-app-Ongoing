using BusinessLayer;
using DataAccessLayer;
using PresentationLayer.Exceptions;
using PresentationLayer.RoomGuestScreen;
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
using static System.Net.Mime.MediaTypeNames;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for RoomAdministrationUserControl.xaml
    /// </summary>
    public partial class RoomAdministrationUserControl : UserControl 
    {
        
        private RoomService roomService;

        public void SetRoomData(List<Room> rooms)
        {

            dgRooms.ItemsSource = rooms;
        }

        public RoomAdministrationUserControl()
        {
            InitializeComponent();
            roomService = new RoomService();
        }

        private void btnAddRoom_Click(object sender, RoutedEventArgs e)
        {

            NavigationManager.Navigate(new AddRoomUserControl());

        }

        private void btnAlterRoom_Click(object sender, RoutedEventArgs e)
        {
            Room room;
            room = dgRooms.SelectedItem as Room;
            AddRoomUserControl alterRoom = new AddRoomUserControl();

            try
            {
                if (room == null)
                {
                    throw new SelectedRoomException("Niste odabrali sobu!");
                } else
                {

                    alterRoom.txtRoomNumber.Text = room.IdRoom.ToString();
                    alterRoom.txtRoomLocation.Text = room.Location;
                    alterRoom.txtRoomPrice.Text = room.Price.ToString();
                    alterRoom.cbmRoomStatus.SelectedItem = room.Room_Status.Status;
                    alterRoom.cbmRoomType.SelectedItem = room.Room_Type.Name;
                    alterRoom.btnAlterSelectedRoom.Visibility = Visibility.Visible;
                    alterRoom.btnAddRoom.Visibility = Visibility.Hidden;
                    NavigationManager.Navigate(alterRoom);
                }

            } catch (SelectedRoomException ex)
            {

                MessageBox.Show(ex.Poruka);
            }

        }

        private void btnDeleteRoom_Click(object sender, RoutedEventArgs e)
        {
            if (dgRooms.SelectedItem != null && dgRooms.SelectedItem is Room selectedRoom)
            {

                roomService.DeleteRoom(selectedRoom);

                LoadGridData();

                MessageBox.Show("Soba uspješno izbrisana!");
            }
        }



        private void dgRooms_Loaded(object sender, RoutedEventArgs e)
        {
            LoadGridData();

        }
        private void AddRoomWindow_Closed(object sender, EventArgs e)
        {
            LoadGridData();
        }
        public async void LoadGridData()
        {
            var rooms = Task.Run(() => roomService.GetAllRooms());
            dgRooms.ItemsSource = await rooms;
           
        }

        

        private void btnOpenRoomScreen_Click(object sender, RoutedEventArgs e)
        {
            Room selectedRoom = dgRooms.SelectedItem as Room;
            NavigationManager.Navigate(new MainRoomScreenView(selectedRoom));
        }

        private void dgRooms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
