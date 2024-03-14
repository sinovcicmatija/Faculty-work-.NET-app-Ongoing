using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class GuestRepository : Repository<Guest>
    {
        public GuestRepository() : base(new DatabaseRPP())
        {
        }
    

        public IQueryable<Guest> GetGuestsBySurname(string phrase)
        {
            var query = from guests in Entities
                        where guests.Name.Split(' ')[1] == phrase
                        select guests;

            return query;
        }

        public IQueryable<Guest> GetGuestsByEmail(string phrase)
        {
            var query = from guests in Entities
                        where guests.Email == phrase
                        select guests;

            return query;
        }

        public Guest GetGuestsByRoom(Room room)
        {
            var reservation = Context.Reservations.FirstOrDefault(r => r.RoomIdRoom == room.IdRoom && r.DateFrom <= DateTime.Today && r.DateTo >= DateTime.Today);

            if (reservation != null)
            {
                var guestId = reservation.GuestIdGuest;

                var query = from guest in Entities
                            where guest.IdGuest == guestId
                            select guest; 

                return query.FirstOrDefault();
            }
            else
            {
                //throw new RoomIsEmptyExeption();
                throw new NotImplementedException();
            }
        }


        public override int Update(Guest entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }
    }
}
