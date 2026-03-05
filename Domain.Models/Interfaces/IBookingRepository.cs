using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Interfaces
{
    public interface IBookingRepository
    {
        Task AddAsync(Booking booking);
        Task UpdateAsync(Booking booking);
        Task DeleteAsync(string bookinId);
        Task<List<Booking>> GetBookingsByUserAndDateAsync(string userId, DateTime date); // alla bokningar för en user för en specifik date
        Task<List<Booking>> GetBookingsByRoomAndDateAsync(string roomId, DateTime date); // alla bokningar för ett rumm för en specifik date
    }
}
