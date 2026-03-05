using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusRoom.Application.Interfaces
{
    public interface ILoginService
    {
        Task<User?> LoginAsync(string email, string password);
    }
}
