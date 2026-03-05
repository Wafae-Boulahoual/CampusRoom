using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusRoom.Application.Interfaces
{
    public interface IRoomService
    {
        Task<List<Room>> GetAllRoomsAsync();
        Task<List<Room>> GetRoomsByFloorAsync(string? floorId = null);
        Task<List<Room>> GetRoomsWithoutDoorAsync();
        Task<List<Room>> GetRoomsWithTVAsync();
        Task<List<Room>> GetRoomWithSpeakerAsync();
    }
}
