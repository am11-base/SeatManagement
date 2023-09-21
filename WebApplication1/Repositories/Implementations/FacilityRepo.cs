using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositories.Implementations
{
    public class FacilityRepo : EntityRepository<Facility>
    {
        public SeatManagementDbContext DbContext { get; set; }
        public FacilityRepo(SeatManagementDbContext dbContext) : base(dbContext)
        {
            DbContext = dbContext;
        }

      
    }
}
