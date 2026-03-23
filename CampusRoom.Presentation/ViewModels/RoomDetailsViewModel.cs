using CampusRoom.Application.Interfaces;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CampusRoom.Presentation.ViewModels
{
    public class RoomDetailsViewModel : INotifyPropertyChanged
    {
        private readonly IRoomService _roomService;
        private readonly IBookingService _bookingService;
        private Room _room;
        public Room Room
        {
            get => _room;
            set
            {
                _room = value;
                OnPropertyChanged(nameof(Room));
            }
        }
        public ObservableCollection<string> AvailableSlots { get; set; } = new(); // uppdaterar UI slots

        public RoomDetailsViewModel(IRoomService roomService, IBookingService bookingService)
        {
            _roomService = roomService;
            _bookingService = bookingService;
        }
        public async Task LoadAvailableSlotsAsync()
        {
            var allPossibleTimes = _roomService.AvailableTimeSlots; // alla slots

            var available = await _bookingService.GetAvailableSlotsAsync(Room.Id,DateTime.Today,allPossibleTimes); // lediga

            AvailableSlots.Clear(); //rensa listan
            foreach (var slot in available)
            {
                AvailableSlots.Add(slot);
            }
        }
        

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
        
}
