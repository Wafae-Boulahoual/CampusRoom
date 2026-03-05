using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusRoom.Application.Interfaces
{
    public interface IBookingService
    {
        Task<List<Booking>> GetUserBookingsAsync(string userId, DateTime date);
        Task<List<Booking>> GetRoomBookingsAsync(string roomId, DateTime date);
        Task AddBookingAsync(Booking booking);
        Task UpdateBookingAsync(Booking booking);
        Task DeleteBookingAsync(string bookingId);
    }
}
