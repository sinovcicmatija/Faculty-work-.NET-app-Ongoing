using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RoomTypeRepository : Repository<Room_Type>
    {
        public RoomTypeRepository() :base(new DatabaseRPP())
        { }

        //public List<Room_Type> GetAllRoomTypes()
        //{
        //    return Entities.ToList();
        //}
        public Room_Type GetRoomTypeByName(string name)
        {
            return Entities.FirstOrDefault(k => k.Name == name);
        }
        //public void AddRoomType(Room_Type roomType) 
        //{
        //    Entities.Add(roomType);
        //    Context.SaveChanges();
        //}

        public override int Update(Room_Type entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }
    }
}
