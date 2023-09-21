using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositories.Implementations
{
    public class DepartmentLookupRepo : EntityRepository<DepartmentLookup>
    {
        private readonly SeatManagementDbContext dbContext;

        public DepartmentLookupRepo(SeatManagementDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
