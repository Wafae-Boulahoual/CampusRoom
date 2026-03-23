using CampusRoom.Application.Interfaces;
using CampusRoom.Infrastructure.Services;
using CampusRoom.Presentation.Services;
using Domain.Models.Entities;
using Domain.Models.Interfaces;
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

        public async Task<string?> LoginAndSaveUserAsync(string email, string password)
        {
            var errorMsg = await _loginFacade.LoginAsync(email, password);
            if (errorMsg == null)
            {
                var user = await _loginFacade.GetUserByEmail(email);
                if (user != null)
                {
                    CurrentUserService.UserId = user.Id;
                    CurrentUserService.UserName = user.Name;
                    CurrentUserService.Education = user.Education;
                }
            }

            return errorMsg;
        }
    }
}
