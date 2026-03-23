using CampusRoom.Infrastructure.Data;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusRoom.Infrastructure.Seeder
{
    public class RoomSeeder
    {
        public static async Task RoomSeedsAsync(CampusRoomDbContext context)
        {
            var rooms = new List<Room>
            {
                // Floor 2
                new Room { RoomNumber = "V216", FloorNumber = "2"},
                new Room { RoomNumber = "V217", FloorNumber = "2" },
                new Room { RoomNumber = "N214", FloorNumber = "2" },
                new Room { RoomNumber = "N213", FloorNumber = "2" },
                new Room { RoomNumber = "N216", FloorNumber  = "2"},
                new Room { RoomNumber = "N217E", FloorNumber  = "2" },
                new Room { RoomNumber = "N217D", FloorNumber  = "2" },
                new Room { RoomNumber = "L246a", FloorNumber  = "2" },
                new Room { RoomNumber = "L246b", FloorNumber  = "2"},
                new Room { RoomNumber = "L246c", FloorNumber  = "2" },

                // Floor 3
                new Room { RoomNumber = "N314", FloorNumber  = "3", HasTv = true },
                new Room { RoomNumber = "N313", FloorNumber  = "3"},
                new Room { RoomNumber = "N316", FloorNumber  = "3", HasSpeaker = true },
                new Room { RoomNumber = "N317", FloorNumber  = "3" },
                new Room { RoomNumber = "M309", FloorNumber  = "3" },
                new Room { RoomNumber = "M308", FloorNumber  = "3" },
                new Room { RoomNumber = "M307", FloorNumber  = "3" },
                new Room { RoomNumber = "Ö312", FloorNumber  = "3" },

                // Floor 4
                new Room { RoomNumber = "N417", FloorNumber  = "4"},
                new Room { RoomNumber = "N416", FloorNumber  = "4" },
                new Room { RoomNumber = "V410", FloorNumber  = "4" },
                new Room { RoomNumber = "V411", FloorNumber  = "4"}
            };

            await context.Rooms.InsertManyAsync(rooms);
        }

    }
}
