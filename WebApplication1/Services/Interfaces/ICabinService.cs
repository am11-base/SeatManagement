using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Services.Interfaces
{
    public interface ICabinService
    {
        string AddCabins(CabinDto cabin);
        FacilityAssetsDto<Cabin> GetFreeCabins(string facility);
        int GetCabinId(int facilityId, string name);
        bool CheckIfAllocated(int cabinId);
        void AllocateCabin(int cabinId);
    }
}
