using CampusRoom.Application.Interfaces;
using Domain.Models.Entities;
using Domain.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusRoom.Application.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        public async Task<List<Room>> GetAllRoomsAsync()
        {
            return await _roomRepository.GetAllAsync();
        }
        public async Task<List<Room>> GetRoomsByFloorAsync(string? floorId = null)
        {
            var rooms = await _roomRepository.GetAllAsync();
            return rooms.Where(r=>r.FloorId == floorId).ToList();
        }

        public async Task<List<Room>> GetRoomsWithoutDoorAsync()
        {
            var rooms = await _roomRepository.GetAllAsync();
            return rooms.Where(r => !r.HasDoor).ToList();
        }

        public async Task<List<Room>> GetRoomsWithTVAsync()
        {
            var rooms = await _roomRepository.GetAllAsync();
            return rooms.Where(r=> r.HasTv).ToList();
        }

        public async Task<List<Room>> GetRoomWithSpeakerAsync()
        {
            var rooms = await _roomRepository.GetAllAsync();
            return rooms.Where(r => r.HasSpeaker).ToList();
        }
    }
}
