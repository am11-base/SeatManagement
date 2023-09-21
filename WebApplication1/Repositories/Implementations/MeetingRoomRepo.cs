using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Repositories.Implementations
{
    public class MeetingRoomRepo : EntityRepository<MeetingRoom>,IRoomRepo
    {
        private readonly SeatManagementDbContext dbContext;

        public MeetingRoomRepo(SeatManagementDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public string? getLastAllocatedRoom(int facility)
        {
            var last = dbContext.Set<MeetingRoom>().Where(room => room.FacilityId == facility).OrderByDescending(room => room.MeetingRoomName).FirstOrDefault();
            if (last == null)
                return null;
            else
                return last.MeetingRoomName;
        }

        public int getRoomId(string name, int facilityId)
        {
            var meetingRoom = dbContext.Set<MeetingRoom>().Where(room => room.MeetingRoomName.Equals(name) && room.FacilityId == facilityId).FirstOrDefault();
            if (meetingRoom == null)
                return -1;
            else
                return meetingRoom.MeetingRoomId;
        }
    }
}
