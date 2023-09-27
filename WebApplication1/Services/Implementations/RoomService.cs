using WebApplication1.DTOs;
using WebApplication1.Exceptions;
using WebApplication1.Models;
using WebApplication1.Repositories.Implementations;
using WebApplication1.Repositories.Interfaces;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services.Implementations
{
    public class RoomService : IRoomService
    {
        private readonly IRepository<MeetingRoom> repository;
        private readonly IFacilityService facilityService;
        private readonly IRoomRepo roomRepo;

        public RoomService(IRepository<MeetingRoom> repository,IFacilityService facilityService,IRoomRepo roomRepo)
        {
            this.repository = repository;
            this.facilityService = facilityService;
            this.roomRepo = roomRepo;
        }
        public string AddRoom(RoomDto roomDto)
        {
            if (!facilityService.CheckIfExists(roomDto.FacilityId))
            {
                throw new NotFoundException("Facility Not Found");
               
            }
            else
            {
                var facilityAbbreviation = facilityService.GetFacilityAbbreviation(roomDto.FacilityId);

                string roomName = $"{facilityAbbreviation}-{GetRoomNumber(roomDto.FacilityId)}";
                MeetingRoom meetingRoom=new MeetingRoom { MeetingRoomName = roomName,FacilityId=roomDto.FacilityId,NumberofChairs=roomDto.numberOfChairs };
                repository.Add(meetingRoom);

                var roomId = GetRoomId(roomName, roomDto.FacilityId);
                if (roomId != -1)
                    return roomId.ToString();
                else
                    throw new NotFoundException("room Not Found");
            }
        }
        public int GetRoomId(string name,int facilityId)
        {
            int roomId=roomRepo.getRoomId(name, facilityId);   
            return roomId;
        }

        private string GetRoomNumber(int facilityId)
        {
            string? lastRoom = roomRepo.getLastAllocatedRoom(facilityId);
            if (lastRoom == null)
            {
                return "M001";
            }
            else
            {
                string numericPart = lastRoom.Substring(lastRoom.LastIndexOf("M") + 1);
                int number = int.Parse(numericPart);
                number++;
                return "M" + number.ToString("D3");
            }
        }
        public bool CheckIfExists(int roomId)
        {
            var room = repository.GetById(roomId);
            if(room == null)
                return false;
            return true;
        }
    }
}
