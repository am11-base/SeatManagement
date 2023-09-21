using WebApplication1.Models;

namespace WebApplication1.Services.Interfaces
{
    public interface IAmenityService
    {
        bool CheckIfExists(int amenityId);
        IEnumerable<Amenity> GetAllAmenities();
    }
}
