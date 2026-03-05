using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmail(string email); // no async för att vi ska inte skapa nya users eller ändra de
    }
}
