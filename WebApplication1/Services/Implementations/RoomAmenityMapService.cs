using WebApplication1.DTOs;
using WebApplication1.Exceptions;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services.Implementations
{
    public class RoomAmenityMapService : IRoomAmenityMapService
    {
        private readonly IRepository<RoomAmenityMap> repository;
        private readonly IRoomService roomService;
        private readonly IAmenityService amenityService;

        public RoomAmenityMapService(IRepository<RoomAmenityMap> repository,IRoomService roomService,IAmenityService amenityService)
        {
            this.repository = repository;
            this.roomService = roomService;
            this.amenityService = amenityService;
        }
        public void AddMapping(int roomId,int amenityId )
        {
            //check if roomid exist
            if(!roomService.CheckIfExists( roomId ))
            {
                throw new CustomException("Room don't exist");
            }
            if(!amenityService.CheckIfExists(amenityId))
            {
                throw new CustomException("Amenity don't exist");
            }

            //check if amenity id exist
            RoomAmenityMap roomAmenityMap = new RoomAmenityMap { AmenityId = amenityId, RoomId = roomId };
            repository.Add(roomAmenityMap);
        }
    }
}
