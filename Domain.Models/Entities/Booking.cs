using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Entities
{
    public class Booking
    {
        [BsonId] // primärnyckeln
        [BsonRepresentation(BsonType.ObjectId)] // översättare
        public string? Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string RoomId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; }

        public string RoomNumber { get; set; } 
        public string Floor { get; set; }
        public DateTime Date { get; set; }
        public string TimeSlot { get; set; } // Förenklar bokningslogik genom att använda fasta tidsintervall som string.
    }
}
