using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services.Implementations
{
    public class RoomAmenityMapService : IRoomAmenityMapService
    {
        private readonly IRepository<RoomAmenityMap> repository;

        public RoomAmenityMapService(IRepository<RoomAmenityMap> repository)
        {
            this.repository = repository;
        }
        public void AddMapping(RoomAmenityMapDto roomAmenityMapData)
        {
            RoomAmenityMap roomAmenityMap = new RoomAmenityMap { AmenityId = roomAmenityMapData.AmenityId, RoomId = roomAmenityMapData.RoomId };
            repository.Add(roomAmenityMap);
        }
    }
}
