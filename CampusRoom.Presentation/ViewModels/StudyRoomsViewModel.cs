using CampusRoom.Application.Interfaces;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusRoom.Presentation.ViewModels
{
    public class StudyRoomsViewModel
    {
        private readonly IRoomService _roomService;
        public ObservableCollection<Room> Rooms { get; set; } = new();
        private List<Room> allRooms = new List<Room>();
        public StudyRoomsViewModel(IRoomService roomService)
        {
            _roomService = roomService;
        }

        public async Task LoadRooms()
        {
            var roomsFromDB = await _roomService.GetAllRoomsAsync();

            allRooms = roomsFromDB.ToList();

            Rooms.Clear();

            foreach (var room in allRooms)
                Rooms.Add(room);
        }
        public void ApplyFilter(string filter)
        {
            Rooms.Clear();

            foreach (var room in allRooms)
            {
                if (filter == "Våning 2" && room.FloorId == "2")
                    Rooms.Add(room);

                else if (filter == "Våning 3" && room.FloorId == "3")
                    Rooms.Add(room);

                else if (filter == "Våning 4" && room.FloorId == "4")
                    Rooms.Add(room);

                else if (filter == "Med skärm" && room.HasTv)
                    Rooms.Add(room);

                else if (filter == "Med högtalare" && room.HasSpeaker)
                    Rooms.Add(room);

                else if (filter == "Inga dörrar" && !room.HasDoor)
                    Rooms.Add(room);

                else if (filter == "Alla")
                    Rooms.Add(room);
            }
        }
    }
}
