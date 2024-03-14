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
    /// Interaction logic for AddRoomTypeWindow.xaml
    /// </summary>
    public partial class AddRoomTypeWindow : Window
    {
        RoomService roomService;
        public AddRoomTypeWindow()
        {
            roomService = new RoomService();
            InitializeComponent();
        }

        private void btnAddRoomType_Click(object sender, RoutedEventArgs e)
        {
            var roomName = txtRoomType.Text;
            var roomDescription = txtRoomDescription.Text;
            var roomNoOfBeds = txtNumberOfBeds.Text;

            Room_Type roomType = new Room_Type()
            {
                Name = roomName,
                DescriptionOfType = roomDescription,
                NoOfBeds = int.Parse(roomNoOfBeds)
            };
            roomService.AddRoomType(roomType);

            this.Close();
            MessageBox.Show("Tip sobe uspješno dodan!");

        }
    }
}
