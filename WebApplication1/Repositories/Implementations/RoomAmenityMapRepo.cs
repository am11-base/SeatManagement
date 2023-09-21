using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositories.Implementations
{
    public class RoomAmenityMapRepo : EntityRepository<RoomAmenityMap>
    {
        private readonly SeatManagementDbContext dbContext;

        public RoomAmenityMapRepo(SeatManagementDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
