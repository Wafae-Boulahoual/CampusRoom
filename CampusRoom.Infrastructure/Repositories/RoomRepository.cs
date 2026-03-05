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
    public class RoomRepository : IRoomRepository
    {
        private readonly CampusRoomDbContext _context;
        public RoomRepository(CampusRoomDbContext context)
        {
            _context = context;
        }

        public async Task<List<Room>> GetAllAsync(string? floorId = null) //read
        {
            if(floorId == null)
            {
                return await _context.Rooms.Find(FilterDefinition<Room>.Empty).ToListAsync();
            }
            return await _context.Rooms
                .Find (r=> r.FloorId == floorId)
                .ToListAsync();
        }

        public async Task<Room?> GetByIdAsync(string Id) // read
        {
            return await _context.Rooms
                .Find(r => r.Id == Id)
                .FirstOrDefaultAsync();
        }
    }
}
