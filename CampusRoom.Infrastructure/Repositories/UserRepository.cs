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
    public class UserRepository : IUserRepository
    {
        private readonly CampusRoomDbContext _context;
        public UserRepository(CampusRoomDbContext context)
        {
            _context = context;
        }
        public async Task<User?> GetUserByEmail(string email) //read
        {
            return await _context.Users
                .Find(u => u.Email == email)
                .FirstOrDefaultAsync();
        }
    }
}
