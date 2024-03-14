using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RoomRepository : Repository<Room>
    {
        public RoomRepository() :base(new DatabaseRPP()) 
        { }

        //public List<Room> GetAllRooms()
        //{
        //    return Entities.ToList();
        //}
        //public void AddRoom(Room room)
        //{
        //    Entities.Add(room);
        //    Context.SaveChanges();
        //}
        //public void DeleteRoom(Room room)
        //{
        //    Entities.Remove(room);
        //    Context.SaveChanges();
        //}
        public void UpdateRoom(Room room) 
        {
            Entities.AddOrUpdate(room);
            Context.SaveChanges();
        }
        public bool IsRoomNumberTaken(int roomNumber)
        {
            return Entities.Any(k => k.IdRoom == roomNumber);
        }

        public override int Update(Room entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }
    }
    
}
