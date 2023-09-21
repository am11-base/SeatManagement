using WebApplication1.Models;

namespace WebApplication1.Services.Interfaces
{
    public interface IAmenityService
    {
        IEnumerable<Amenity> GetAllAmenities();
    }
}
