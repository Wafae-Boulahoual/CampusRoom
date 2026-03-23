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
            return await _bookingRepository.GetBookingsByUserAsync(userId, date);
        }
       
        public async Task CreateMultipleBookingsAsync(string roomId, string userId, DateTime date, List<string> selectedSlots,string roomNumber, string floor)
        {
            if (selectedSlots == null || selectedSlots.Any() == false)
            {
                return;
            }

            var bookingDate = date.Date;
            var existingBookings = await _bookingRepository.GetBookingsByRoomAndDateAsync(roomId, bookingDate);

            var newBookings = new List<Booking>(); 

            foreach (var slot in selectedSlots)
            {
                newBookings.Add(new Booking
                {
                    Id = null, 
                    RoomId = roomId,
                    UserId = userId,
                    Date = bookingDate,
                    TimeSlot = slot,
                    RoomNumber = roomNumber,
                    Floor = floor
                });
            }
 
            foreach (var b in newBookings)
            {
                await _bookingRepository.AddAsync(b);
            }
        }

        public async Task<List<string>> GetAvailableSlotsAsync(string roomId, DateTime date, List<string> allPossibleSlots)
        {
            var booked = await _bookingRepository.GetBookingsByRoomAndDateAsync(roomId, date);

            var occupied = booked.Select(b => b.TimeSlot).ToList();

            var available = new List<string>();

            var currentTime = DateTime.Now.TimeOfDay;

            bool isToday = date.Date == DateTime.Today;

            foreach (var slot in allPossibleSlots)
            {
                bool isOccupied = occupied.Contains(slot);

                var startTimeString = slot.Split('-')[0]; //tar första delen av strängen
                var startTime = TimeSpan.Parse(startTimeString);//omvandla den till tid

                if (isOccupied == false)
                {
                    if (isToday == false || startTime > currentTime)
                    {
                        available.Add(slot);
                    }
                }
            }
            return available;
        }
    }
}
