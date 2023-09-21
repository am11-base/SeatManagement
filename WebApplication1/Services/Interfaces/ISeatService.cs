using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Services.Interfaces
{
    public interface ISeatService
    {
        FacilityAssetsDto<Seat> GetFreeSeats(string facility);
        string AddSeats(SeatDto seat);
        int GetSeatId(int facilityId, string name);
        bool CheckIfAllocated(int seatId);
        void AllocateSeat(int seatId);
    }
}
