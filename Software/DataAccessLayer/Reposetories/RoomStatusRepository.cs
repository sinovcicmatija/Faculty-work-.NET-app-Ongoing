using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Reposetories
{
    public class RoomStatusRepository : Repository<Room_Status>
    {
        public RoomStatusRepository() : base(new DatabaseRPP())
        {
        }

        public Room_Status GetRoomStatusByName(string name)
        {
            return Entities.FirstOrDefault(k => k.Status == name);
        }
        public override int Update(Room_Status entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }


    }
}
