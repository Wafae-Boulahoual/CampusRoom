using CampusRoom.Infrastructure.Data;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusRoom.Infrastructure.Seeder
{
    public class UserSeeder
    {
        public static async Task UserSeedsAsync(CampusRoomDbContext context)
        {
            var users = new List<User>
            {
                new User { Name = "Lina Essiya", Email = "lina.essiya@gmail.com", Password = "1234", Education = "Automationsingenjör" },
                new User { Name = "Marco Rossi", Email = "marco.rossi@example.com", Password = "1234", Education = "Elkonstruktör" },
                new User { Name = "Emma Johansson", Email = "emma.johansson@example.com", Password = "1234", Education = "Elkraftingenjör" },
                new User { Name = "Liam Karlsson", Email = "liam.karlsson@example.com", Password = "1234", Education = "Eltekniker - järnväg" },
                new User { Name = "Sofia Eriksson", Email = "sofia.eriksson@example.com", Password = "1234", Education = "Equiterapeut" },
                new User { Name = "Ahmed Mohamed", Email = "ahmed.mohamed@example.com", Password = "1234", Education = "Medicinsk vårdadministratör" },
                new User { Name = "Nina Lind", Email = "nina.lind@example.com", Password = "1234", Education = "Musik- och eventarrangör" },
                new User { Name = "Oskar Nilsson", Email = "oskar.nilsson@example.com", Password = "1234", Education = "Odlare – företagande och innovation" },
                new User { Name = "Fatima Hassan", Email = "fatima.hassan@example.com", Password = "1234", Education = "Projektledare elteknik" },
                new User { Name = "Hanna Gustafsson", Email = "hanna.gustafsson@example.com", Password = "1234", Education = "Ridlärare" },
                new User { Name = "David Pettersson", Email = "david.pettersson@example.com", Password = "1234", Education = "Signaltekniker" },
                new User { Name = "Sara Karim", Email = "sara.karim@example.com", Password = "1234", Education = "Socialpedagog" },
                new User { Name = "Mikael Andersson", Email = "mikael.andersson@example.com", Password = "1234", Education = "Specialistundersköterska inom vård och omsorg av äldre" },
                new User { Name = "Leila Ahmed", Email = "leila.ahmed@example.com", Password = "1234", Education = "Stödpedagog inom funktionshinderområdet" },
                new User { Name = "Erik Olsson", Email = "erik.olsson@example.com", Password = "1234", Education = "Systemutvecklare .NET" },
                new User { Name = "Mona Ali", Email = "mona.ali@example.com", Password = "1234", Education = "Tandsköterska" },
                new User { Name = "Johan Svensson", Email = "johan.svensson@example.com", Password = "1234", Education = "Trafiklärare" },
                new User { Name = "Sara Lindqvist", Email = "sara.lindqvist@example.com", Password = "1234", Education = "VA-ingenjör" },
                new User { Name = "Ali Reza", Email = "ali.reza@example.com", Password = "1234", Education = "Automationsselektriker (Komvux)" },
                new User { Name = "Emma Berg", Email = "emma.berg@example.com", Password = "1234", Education = "Kock" }
            };

            await context.Users.InsertManyAsync(users);
        }
    }
}
