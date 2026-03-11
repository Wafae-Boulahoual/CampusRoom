using CampusRoom.Application.Interfaces;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusRoom.Presentation.ViewModels
{
    public class LoginViewModel
    {
        private readonly ILoginFacade _loginFacade;

        public LoginViewModel(ILoginFacade loginFacade)
        {
            _loginFacade = loginFacade;
        }

        public string Email { get; set; }
        public string Password { get; set; }
        public User LoggedUser { get; private set; }

        public async Task<(bool success, string? message)> LoginAsync()
        {
            var errorMsg = await _loginFacade.LoginAsync(Email, Password);

            if (errorMsg != null)
            {
              
                return (false, errorMsg);
            }

            LoggedUser = await _loginFacade.GetUserByEmail(Email);
            return (true, null);
            
        }
    }
}
