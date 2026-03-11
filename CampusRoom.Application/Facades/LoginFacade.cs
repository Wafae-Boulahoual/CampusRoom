using CampusRoom.Application.Interfaces;
using Domain.Models.Entities;
using Domain.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CampusRoom.Application.Facades
{
    public class LoginFacade: ILoginFacade
    {
        private readonly IUserRepository _userRepository;
        public LoginFacade(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _userRepository.GetUserByEmail(email);
        }

        public async Task<string?> LoginAsync(string email, string password)
        {
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                return "Ogiltig e-postadress";
            }

            var user = await _userRepository.GetUserByEmail(email);

            if (user == null)
            {
                return "Du är inte registrerad i campus. Vänligen kontakta informationskontoret.";
            }
            if (user.Password != password)
            {
                return "Fel lösenord!";
            }

            return null;
        }

    }
}
     
