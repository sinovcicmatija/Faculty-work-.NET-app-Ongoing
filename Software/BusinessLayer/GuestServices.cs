using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class GuestServices
    {
        public Guest GetGuestByRoom(Room room)
        {
            using (var context = new GuestRepository())
            {
                return context.GetGuestsByRoom(room) as Guest;
            }
        }
    }
}
