using WebApplication1.Models;

namespace WebApplication1.Repositories.Interfaces
{
    public interface ICabinRepo
    {
        IEnumerable<Cabin> GetFreeCabins(int facilityId);
        string? getLastAllocatedCabin(int facility);
        int GetCabinId(int facilityId, string name);
    }
}
