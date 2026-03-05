using CampusRoom.Application.Interfaces;
using Domain.Models.Entities;
using Domain.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CampusRoom.Application.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;
        public LoginService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User?> LoginAsync(string email, string password)
        {
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                return null;
            }

            var user = await _userRepository.GetUserByEmail(email);

            if (user == null || user.Password != password)
            {
                return null;
            }
            return user;
        }
    }
}
