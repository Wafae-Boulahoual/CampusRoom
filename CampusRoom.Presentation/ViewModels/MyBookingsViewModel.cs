using CampusRoom.Application.Interfaces;
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
    public class MyBookingsViewModel
    {
        private readonly IBookingService _bookingService;
        public ObservableCollection<Booking> Bookings { get; set; } = new(); // uppdaterats i UI

        public MyBookingsViewModel(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public async Task LoadBookings()
        {
            var userId = CurrentUserService.UserId;
           
            var userBookings = await _bookingService.GetUserBookingsAsync(userId, DateTime.Today);

            Bookings.Clear();
            foreach (var booking in userBookings)
            {
                Bookings.Add(booking);
            }

        }

        public async Task CancelBookingAsync(Booking booking)
        {
            await _bookingService.DeleteBookingAsync(booking.Id);
            Bookings.Remove(booking);
        }
    }
}
