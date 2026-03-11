using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Entities
{
    public class Booking
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string RoomId { get; set; }
        public string UserId { get; set; }
        public DateTime Date {  get; set; } // vi hanterar bokiningar för endast samma dag
        public DateTime StartTime { get; set; } = DateTime.Now;// vi hanterar olika tider på samma dag
        public DateTime EndTime { get; set; } = DateTime.Now.AddDays(1);
    }
}
