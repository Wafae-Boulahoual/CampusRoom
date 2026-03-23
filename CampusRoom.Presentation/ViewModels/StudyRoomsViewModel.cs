using CampusRoom.Application.Interfaces;
using CampusRoom.Application.Services;
using CampusRoom.Presentation.Services;
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
        public ObservableCollection<Room> Rooms { get; set; } = new(); // uppdaterar UI rummen
        private List<Room> allRooms = new List<Room>(); // behövs inte att anropa på db

        public string UserName => CurrentUserService.UserName; // ska användas för välkommen text
        public StudyRoomsViewModel(IRoomService roomService)
        {
            _roomService = roomService;
        }
        public async Task LoadRooms()
        {
            allRooms = (await _roomService.GetAllRoomsAsync()).ToList();

            Rooms.Clear(); // rensar om jag väljer en filter

            foreach (var room in allRooms)
            {
                Rooms.Add(room);
                
            }
        }
        public void ApplyFilter(string filter)
        {
            Rooms.Clear();
            foreach (var room in allRooms)
            {
                if (filter == "Våning 2" && room.FloorNumber == "2") //kontrollerar UI(picker) & Databasen
                {
                    Rooms.Add(room);
                }
                else if (filter == "Våning 3" && room.FloorNumber == "3")
                {
                    Rooms.Add(room);
                }
                else if (filter == "Våning 4" && room.FloorNumber == "4")
                {
                    Rooms.Add(room);
                }
                else if (filter == "Med skärm" && room.HasTv)
                {
                    Rooms.Add(room);
                }
                else if (filter == "Med högtalare" && room.HasSpeaker)
                {
                    Rooms.Add(room);
                }

                else if (filter == "Alla")
                {
                    Rooms.Add(room);
                }
            }
        }
    }
}
