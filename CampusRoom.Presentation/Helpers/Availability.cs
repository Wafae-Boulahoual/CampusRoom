using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusRoom.Presentation.Helpers
{
    public class Availability
    {
        public static string GetAvailabilityText(Room room, List<Booking> bookings)
        {
            var allSlots = new List<string>
        {
            "08:00 - 10:00",
            "10:00 - 12:00",
            "12:00 - 14:00",
            "14:00 - 16:00",
            "16:00 - 18:00",
            "18:00 - 20:00"
        };

            // Slot già prenotati
            var bookedSlots = bookings.Select(b => b.TimeSlot).ToList();

            // Slot disponibili
            var availableSlots = allSlots.Except(bookedSlots).ToList();

            if (availableSlots.Count == 0)
                return "Ingen tillgänglighet idag";

            return "Tillgängliga tider: " + string.Join(", ", availableSlots);
        }
    }
}
