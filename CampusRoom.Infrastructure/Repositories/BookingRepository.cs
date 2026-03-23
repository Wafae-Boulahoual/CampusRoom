using CampusRoom.Infrastructure.Data;
using Domain.Models.Entities;
using Domain.Models.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusRoom.Infrastructure.Services
{
    public class BookingRepository : IBookingRepository
    {
        private CampusRoomDbContext _context;
        public BookingRepository(CampusRoomDbContext context) 
        {
            _context = context;
        }
        public async Task AddAsync(Booking booking) // create
        {
            await _context.Bookings.InsertOneAsync(booking);
        }
        public async Task DeleteAsync(string bookingId) //delete
        {
            await _context.Bookings.DeleteOneAsync(b => b.Id == bookingId);
        }
        public async Task<List<Booking>> GetBookingsByRoomAndDateAsync(string roomId, DateTime date)// read
        {
            var start = date.Date;
            var end = start.AddDays(1);

            return await _context.Bookings
                .Find(b => b.RoomId == roomId && b.Date >= start && b.Date < end)
                .ToListAsync();
        }
        public async Task<List<Booking>> GetBookingsByUserAsync(string userId, DateTime date) // read
        {
            //bokningen kan göras bara för samma dag
            var dayStart = date.Date; 
            var dayEnd = dayStart.AddDays(1);
           
            return await _context.Bookings
                .Find(b => b.UserId == userId &&
                           b.Date >= dayStart &&
                           b.Date < dayEnd)
                .ToListAsync();
        }
       
    }
}
