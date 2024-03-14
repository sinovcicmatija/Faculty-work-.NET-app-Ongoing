using BusinessLayer;
using DataAccessLayer;
using PresentationLayer.Exceptions;
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

namespace PresentationLayer
{

    public partial class AddRoomUserControl : UserControl
    {
        RoomService roomService;

        public AddRoomUserControl()
        {
            roomService = new RoomService();
            InitializeComponent(); 
            LoadRoomTypes();
            LoadRoomStatus();
        }

        private void btnAddNewRoomType_Click(object sender, RoutedEventArgs e)
        {
            AddRoomTypeWindow addRoomType = new AddRoomTypeWindow();
            addRoomType.Owner = Window.GetWindow(this);
            addRoomType.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            addRoomType.Closed += AddRoomTypeWindow_Closed;
            NavigationManager.Navigate(addRoomType);

        }

        private void cbmRoomType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedRoomType = cbmRoomType.SelectedItem as string;
            Room_Type room_Type = new Room_Type();
            room_Type = roomService.GetRoomTypeByName(selectedRoomType);
            txtRoomDescription.Text = room_Type.DescriptionOfType;
            txtNoOfBeds.Text = room_Type.NoOfBeds.ToString();

        }
        private void LoadRoomTypes()
        {
            var roomTypes = roomService.GetAllRoomTypes();
            cbmRoomType.ItemsSource = roomTypes.Select(v => v.Name).ToList();
        }

        private void LoadRoomStatus()
        {
            var roomStatus = roomService.GetAllRoomStatuses();
            cbmRoomStatus.ItemsSource = roomStatus.Select(v => v.Status).ToList();
        }
        private void AddRoomTypeWindow_Closed(object sender, EventArgs e)
        {
            LoadRoomTypes();
        }

        private void btnAddRoom_Click(object sender, RoutedEventArgs e)
        {
            var roomNumber = int.Parse(txtRoomNumber.Text);
            var roomLocation = txtRoomLocation.Text;
            var roomPrice = txtRoomPrice.Text;
            var selectedRoomStatus = cbmRoomStatus.SelectedItem as String;
            Room_Status room_status = new Room_Status();
            room_status = roomService.GetRoomStatusByName(selectedRoomStatus);
            var selectedRoomType = cbmRoomType.SelectedItem as String;
            Room_Type room_type = new Room_Type();
            room_type = roomService.GetRoomTypeByName(selectedRoomType);


            try
            {
                if (roomService.IsRoomNumberTaken(roomNumber))
                {
                    throw new SaveRoomException("Broj sobe je već zauzet!");

                }
                if (selectedRoomType == null)
                {
                    throw new SaveRoomException("Niste odabrali tip sobe!");
                }
                if (roomLocation == null)
                {
                    throw new SaveRoomException("Niste naveli lokaciju sobe!");
                }
                if (string.IsNullOrWhiteSpace(roomPrice))
                {
                    throw new SaveRoomException("Niste naveli cijenu sobe!");
                }

                if (!double.TryParse(roomPrice, out double parsedPrice))
                {
                    throw new SaveRoomException("Neispravna cijena sobe.");
                } else
                {
                    Room room = new Room()
                    {
                        IdRoom = roomNumber,
                        Location = roomLocation,
                        Price = double.Parse(roomPrice),
                        RoomStatusIdRoomStatus = room_status.IdRoomStatus,
                        RoomTypeIdRoomType = room_type.IdRoomType
                    };

                    roomService.AddRoom(room);
                    NavigationManager.Navigate(new RoomAdministrationUserControl());
                    MessageBox.Show("Soba uspješno dodana");

                }

            } catch (SaveRoomException ex)
            {
                MessageBox.Show(ex.Poruka);
            }
        }

        private void btnAlterSelectedRoom_Click(object sender, RoutedEventArgs e)
        {
            var roomNumber = int.Parse(txtRoomNumber.Text);
            var roomLocation = txtRoomLocation.Text;
            var roomPrice = txtRoomPrice.Text;
            var selectedRoomStatus = cbmRoomStatus.SelectedItem as String;
            Room_Status room_status = new Room_Status();
            room_status = roomService.GetRoomStatusByName(selectedRoomStatus);
            var selectedRoomType = cbmRoomType.SelectedItem as String;
            Room_Type room_type = new Room_Type();
            room_type = roomService.GetRoomTypeByName(selectedRoomType);

            Room room = new Room()
            {
                IdRoom = roomNumber,
                Location = roomLocation,
                Price = double.Parse(roomPrice),
                RoomStatusIdRoomStatus = room_status.IdRoomStatus,
                RoomTypeIdRoomType = room_type.IdRoomType
            };

            roomService.UpdateRoom(room);
            NavigationManager.Navigate(new RoomAdministrationUserControl());
            MessageBox.Show("Soba uspješno promjenjena!");



        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.Navigate(new RoomAdministrationUserControl());
        }
    }
}

