using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositories.Implementations
{
    public class EmployeeRepo : EntityRepository<Employee>
    {
        private readonly SeatManagementDbContext dbContext;

        public EmployeeRepo(SeatManagementDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
