using System.ComponentModel.DataAnnotations;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Repositories.Implementations
{
    public class CabinRepo : EntityRepository<Cabin>, ICabinRepo
    {
        private readonly SeatManagementDbContext dbContext;

        public CabinRepo(SeatManagementDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Cabin> GetFreeCabins(int facility)
        {
            return dbContext.Set<Cabin>().Where(cabin => cabin.FacilityId == facility && cabin.IsAssigned == false).ToList();

        }

        public string? getLastAllocatedCabin(int facility)
        {
            var last = dbContext.Set<Cabin>().Where(cabin => cabin.FacilityId == facility).OrderByDescending(cabin => cabin.CabinName).FirstOrDefault();
            if (last == null)
                return null;
            else
                return last.CabinName;
        }
        public int GetCabinId(int facilityId, string name)
        {
            var cabin=dbContext.Set<Cabin>().Where(cabin => cabin.FacilityId == facilityId && cabin.CabinName==name).FirstOrDefault();
            if (cabin == null)
                return -1;
            else
                return cabin.CabinId;
        }
        
    }
}
