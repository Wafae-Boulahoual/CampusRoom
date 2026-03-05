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
                new Room { RoomNumber = "V216", FloorId = "2", HasWindows = true, HasDoor = true },
                new Room { RoomNumber = "V217", FloorId = "2", HasWindows = true, HasDoor = true },
                new Room { RoomNumber = "N214", FloorId = "2", HasWindows = true, HasDoor = true },
                new Room { RoomNumber = "N213", FloorId = "2", HasWindows = true, HasDoor = true },
                new Room { RoomNumber = "N216", FloorId = "2", HasWindows = true, HasDoor = true },
                new Room { RoomNumber = "N217E", FloorId = "2", HasWindows = true, HasDoor = true },
                new Room { RoomNumber = "N217D", FloorId = "2", HasWindows = true, HasDoor = true },
                new Room { RoomNumber = "L246a", FloorId = "2", HasWindows = false, HasDoor = false },
                new Room { RoomNumber = "L246b", FloorId = "2", HasWindows = false, HasDoor = false },
                new Room { RoomNumber = "L246c", FloorId = "2", HasWindows = false, HasDoor = false },

                // Floor 3
                new Room { RoomNumber = "N314", FloorId = "3", HasWindows = true, HasDoor = true, HasTv = true },
                new Room { RoomNumber = "N313", FloorId = "3", HasWindows = true, HasDoor = true },
                new Room { RoomNumber = "N316", FloorId = "3", HasWindows = true, HasDoor = true, HasSpeaker = true },
                new Room { RoomNumber = "N317", FloorId = "3", HasWindows = true, HasDoor = true },
                new Room { RoomNumber = "M309", FloorId = "3", HasWindows = true, HasDoor = true },
                new Room { RoomNumber = "M308", FloorId = "3", HasWindows = true, HasDoor = true },
                new Room { RoomNumber = "M307", FloorId = "3", HasWindows = true, HasDoor = true },
                new Room { RoomNumber = "Ö312", FloorId = "3", HasWindows = true, HasDoor = true },

                // Floor 4
                new Room { RoomNumber = "N417", FloorId = "4", HasWindows = true, HasDoor = true },
                new Room { RoomNumber = "N416", FloorId = "4", HasWindows = true, HasDoor = true },
                new Room { RoomNumber = "V410", FloorId = "4", HasWindows = true, HasDoor = true },
                new Room { RoomNumber = "V411", FloorId = "4", HasWindows = true, HasDoor = true }
            };

            await context.Rooms.InsertManyAsync(rooms);
        }

    }
}
