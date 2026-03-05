using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Entities
{
    public class Room
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string RoomNumber { get; set; }
        public string FloorId { get; set; }
        public bool HasWindows { get; set; }
        public bool HasDoor { get; set; }
        public bool HasTv { get; set; }
        public bool HasSpeaker { get; set; }
        public int Capacity { get; set; } = 6;

    }
}
