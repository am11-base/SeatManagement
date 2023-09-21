using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositories.Implementations
{
    public class AmenityRepo : EntityRepository<Amenity>
    {
        private readonly SeatManagementDbContext dbContext;

        public AmenityRepo(SeatManagementDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
