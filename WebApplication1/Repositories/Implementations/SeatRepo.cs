using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Repositories.Implementations
{
    public class SeatRepo : EntityRepository<Seat>,ISeatRepo
    {
        private readonly SeatManagementDbContext dbContext;

        public SeatRepo(SeatManagementDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
        public string? getLastAllocatedSeat(int facility)
        {
            var last = dbContext.Set<Seat>().Where(seat => seat.FacilityId == facility).OrderByDescending(seat => seat.SeatName).FirstOrDefault();
            if(last == null)
                return null;
            else
                return last.SeatName;
        }
        public IEnumerable<Seat> GetFreeSeats(int facility)
        {
            return dbContext.Set<Seat>().Where(seat => seat.FacilityId == facility && seat.IsAssigned == false).ToList();
        }
        public int? GetSeatId(int facilityId, string name)
        {
            var seat = dbContext.Set<Seat>().Where(seat => seat.FacilityId == facilityId && seat.SeatName == name).FirstOrDefault();
            if (seat == null)
                return null;
            else
                return seat.SeatId;
        }
    }
}
