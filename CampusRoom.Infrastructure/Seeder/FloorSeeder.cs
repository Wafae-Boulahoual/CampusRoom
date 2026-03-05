using CampusRoom.Infrastructure.Data;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusRoom.Infrastructure.Seeder
{
    public class FloorSeeder
    {
        public static async Task FloorSeedsAsync(CampusRoomDbContext context)
        {
            var floors = new List<Floor>
            {
                new Floor { FloorNumber = "2", Description = "EntreVåning" },
                new Floor { FloorNumber = "3", Description = "En trappa upp entreVåning" },
                new Floor { FloorNumber = "4", Description = "Två trappor upp entreVåning" }
            };
            await context.Floors.InsertManyAsync(floors);
        }
    }
}
