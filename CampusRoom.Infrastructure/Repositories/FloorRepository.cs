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
    public class FloorRepository : IFloorRepository
    {
        private readonly CampusRoomDbContext _context;
        public FloorRepository(CampusRoomDbContext context)
        {
            _context = context;
        }
        public async Task<List<Floor>> GetAllAsync() // read
        {
            return await _context.Floors.Find(FilterDefinition<Floor>.Empty).ToListAsync();

        }
    }
}
