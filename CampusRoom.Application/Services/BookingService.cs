using CampusRoom.Application.Interfaces;
using Domain.Models.Entities;
using Domain.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CampusRoom.Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public async Task AddBookingAsync(Booking booking)
        {
            await _bookingRepository.AddAsync(booking);
        }

        public async Task DeleteBookingAsync(string bookingId)
        {
            await _bookingRepository.DeleteAsync(bookingId);
        }

        public async Task<List<Booking>> GetRoomBookingsAsync(string roomId, DateTime date)
        {
            return await _bookingRepository.GetBookingsByRoomAndDateAsync(roomId, date);
        }

        public async Task<List<Booking>> GetUserBookingsAsync(string userId, DateTime date)
        {
            return await _bookingRepository.GetBookingsByUserAndDateAsync(userId, date);
        }
        public async Task UpdateBookingAsync(Booking booking)
        {
            await _bookingRepository.UpdateAsync(booking);
        }
        public async Task CreateMultipleBookingsAsync(string roomId, string userId, DateTime date, List<string> selectedSlots)
        {
            if (selectedSlots == null || selectedSlots.Count == 0)
                return;

            foreach (var slot in selectedSlots)
            {
                var booking = new Booking
                {
                    RoomId = roomId,
                    UserId = userId,
                    Date = date,
                    TimeSlot = slot
                };
                await _bookingRepository.AddAsync(booking);
            }
        }

    }
}
