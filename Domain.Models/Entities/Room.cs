using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Entities
{
    public class Room
    {
        [BsonId] 
        [BsonRepresentation(BsonType.ObjectId)] 
        public string Id { get; set; } 
        public string RoomNumber { get; set; }
        public string FloorNumber { get; set; }
        public bool HasTv { get; set; }
        public bool HasSpeaker { get; set; }
        public int Capacity { get; set; } = 6;
    }
}
