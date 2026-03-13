using CampusRoom.Application.Interfaces;
using CampusRoom.Presentation.Helpers;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusRoom.Presentation.ViewModels
{
    public class RoomDetailsViewModel : INotifyPropertyChanged
    {
        private readonly IRoomService _roomService;
        private readonly IBookingService _bookingService;

        // Queste due proprietà servono alla pagina per mostrare i dati
        private Room _room { get; set; }
        public Room Room
        {
            get => _room;
            set
            {
                _room = value;
                OnPropertyChanged(nameof(Room));
            }
        }
        private string _availabilityText { get; set; }
        public string AvailabilityText
        {
            get => _availabilityText;
            set
            {
                _availabilityText = value;
                OnPropertyChanged(nameof(AvailabilityText));
            }
        }
        public RoomDetailsViewModel(IRoomService roomService, IBookingService bookingService)
        {
            _roomService = roomService;
            _bookingService = bookingService;
        }

        public async Task LoadRoom(Room room)
        {
            Room = room;
            var bookings = await _bookingService.GetRoomBookingsAsync(room.Id, DateTime.Today);
            AvailabilityText = Availability.GetAvailabilityText(room, bookings);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
