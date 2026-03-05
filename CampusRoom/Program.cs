using CampusRoom.Infrastructure.Data;
using CampusRoom.Infrastructure.Seeder;
using Microsoft.Extensions.Configuration;

namespace CampusRoom
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();

            string connectionString = config["MongoDB:ConnectionString"];
            string databaseName = config["MongoDB:DatabaseName"];

            var dbContext = new CampusRoomDbContext(connectionString, databaseName);

            //await UserSeeder.UserSeedsAsync(dbContext);
            //await RoomSeeder.RoomSeedsAsync(dbContext);
            //await FloorSeeder.FloorSeedsAsync(dbContext);
            //Console.WriteLine("Seeding...Done!");
        }
    }
}
