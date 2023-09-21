using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Repositories.Implementations
{
    public class AssetAllocationRepo : EntityRepository<AssetAllocation>,IAllocationRepo
    {
        private readonly SeatManagementDbContext dbContext;

        public AssetAllocationRepo(SeatManagementDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool CheckIfEmployeeAllocated(int empId)
        {
            var allocation=dbContext.Set<AssetAllocation>().Where(allocation=>allocation.EmployeeId == empId).FirstOrDefault();
            if(allocation==null)
                return false;
            else
                return true;
        }
    }
}
