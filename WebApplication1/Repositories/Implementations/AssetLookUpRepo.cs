using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositories.Implementations
{
    public class AssetLookUpRepo : EntityRepository<AssetLookup>
    {
        private readonly SeatManagementDbContext dbContext;

        public AssetLookUpRepo(SeatManagementDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
