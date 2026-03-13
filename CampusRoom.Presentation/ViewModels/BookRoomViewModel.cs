using CampusRoom.Application.Interfaces;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusRoom.Presentation.ViewModels
{
    public class BookRoomViewModel
    {
        private readonly IBookingService _bookingService;
        private readonly Room _room;

        public ObservableCollection<SlotItem> Slots { get; set; } = new();

        public BookRoomViewModel(Room room, IBookingService bookingService)
        {
            _room = room;
            _bookingService = bookingService;
        }

        public async Task LoadSlots()
        {
            var bookings = await _bookingService.GetRoomBookingsAsync(_room.Id, System.DateTime.Today);

            var allSlots = new List<string>
            {
                "08:00 - 10:00",
                "10:00 - 12:00",
                "12:00 - 14:00",
                "14:00 - 16:00",
                "16:00 - 18:00",
                "18:00 - 20:00"
            };

            Slots.Clear();
            foreach (var slot in allSlots)
            {
                var booked = bookings.Any(b => b.TimeSlot == slot);
                Slots.Add(new SlotItem { Time = slot, IsBooked = booked });
            }
        }

        public async Task ConfirmBookingAsync()
        {
            var selectedSlots = Slots
                .Where(s => s.IsSelected && !s.IsBooked)
                .Select(s => s.Time)
                .ToList();

            await _bookingService.CreateMultipleBookingsAsync(_room.Id, "currentUserId", DateTime.Today, selectedSlots);
        }
    }

    public class SlotItem : INotifyPropertyChanged
    {
        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged(nameof(IsSelected));
                }
            }
        }
        public bool IsBooked { get; set; }
        public string Time { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}
