using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Interfaces
{
    public interface IRoomRepository
    {
        Task<List<Room>> GetAllAsync(string? floorId = null); // ska användas i studyroomspage för alla och med våning filter
       
    }
}
