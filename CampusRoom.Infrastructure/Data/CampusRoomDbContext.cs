using CampusRoom.Infrastructure.Seeder;
using Domain.Models.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusRoom.Infrastructure.Data
{
    public class CampusRoomDbContext
    {
        private readonly IMongoDatabase _database;

        public CampusRoomDbContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<User> Users => _database.GetCollection<User>("Users");
        public IMongoCollection<Room> Rooms => _database.GetCollection<Room>("Rooms");

        public IMongoCollection<Floor> Floors => _database.GetCollection<Floor>("Floors");
        public IMongoCollection<Booking> Bookings => _database.GetCollection<Booking>("Bookings");


    }

}
