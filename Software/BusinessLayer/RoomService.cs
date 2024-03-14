using DataAccessLayer;
using DataAccessLayer.Reposetories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class RoomService
    {
        private RoomRepository roomRepository;
        private RoomTypeRepository roomTypeRepository;
        private RoomStatusRepository roomStatusRepository;

        public RoomService()
        {
            roomRepository = new RoomRepository();
            roomTypeRepository = new RoomTypeRepository();
            roomStatusRepository = new RoomStatusRepository();
        }
        public List<Room> GetAllRooms()
        {
                return roomRepository.GetAll().ToList();
        }
        public void AddRoom(Room room)
        {
            roomRepository.Add(room);
        }
        public void UpdateRoom(Room room)
        {
            roomRepository.UpdateRoom(room);
        }
        public void DeleteRoom(Room room)
        {
            roomRepository.Remove(room);
        }
        public void AddRoomType(Room_Type room_type)
        {
            roomTypeRepository.Add(room_type);
        }
        public List<Room_Type> GetAllRoomTypes()
        {
            return roomTypeRepository.GetAll().ToList();
        }
        public Room_Type GetRoomTypeByName(string roomTypeName) 
        {
            return roomTypeRepository.GetRoomTypeByName(roomTypeName);
        }
        public bool IsRoomNumberTaken(int roomNumber)
        {
            return roomRepository.IsRoomNumberTaken(roomNumber);
        }
        public List<Room_Status> GetAllRoomStatuses()
        {
            return roomStatusRepository.GetAll().ToList();
        }
        public Room_Status GetRoomStatusByName(string roomStatus) 
        {
            return roomStatusRepository.GetRoomStatusByName(roomStatus);
        }

    }
}
