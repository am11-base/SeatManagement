using WebApplication1.Exceptions;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services.Implementations
{
    public class AmenityService : IAmenityService
    {
        private readonly IRepository<Amenity> repository;

        public AmenityService(IRepository<Amenity> repository)
        {
            this.repository = repository;
        }

        public bool CheckIfExists(int amenityId)
        {
            var amenity = repository.GetById(amenityId);
            if(amenity== null)
            {
                return false;
            }
            else
                return true;
        }

        public IEnumerable<Amenity> GetAllAmenities()
        {
            return repository.GetAll();
        }
    }
}
