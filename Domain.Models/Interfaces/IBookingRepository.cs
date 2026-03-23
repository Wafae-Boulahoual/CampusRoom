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
        Task AddAsync(Booking booking); //create
        Task DeleteAsync(string bookinId); //delete
        Task<List<Booking>> GetBookingsByUserAsync(string userId, DateTime date); // ska användas i mybookingspage
        Task<List<Booking>> GetBookingsByRoomAndDateAsync(string roomId, DateTime date); // ska användas i roomdetailspage
    }
}
