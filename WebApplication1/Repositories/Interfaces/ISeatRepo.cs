using WebApplication1.Models;

namespace WebApplication1.Repositories.Interfaces
{
    public interface ISeatRepo
    {
        IEnumerable<Seat> GetFreeSeats(int facility);
        string? getLastAllocatedSeat(int facility);
        int GetSeatId(int facilityId, string name);
    }
}
