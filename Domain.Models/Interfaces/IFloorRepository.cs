using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Interfaces
{
    public interface IFloorRepository
    {
        Task<List<Floor>> GetAllAsync();
    }
}
