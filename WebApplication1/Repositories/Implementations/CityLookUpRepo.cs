using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Repositories.Implementations
{
    public class CityLookUpRepo : EntityRepository<CityLookUp>,ICityRepo
    {
        private readonly SeatManagementDbContext dbContext;

        public CityLookUpRepo(SeatManagementDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool checkIfExists(CityLookUp cityLookUp)
        {
            var city=dbContext.Set<CityLookUp>().Where(city=>city.CityName==cityLookUp.CityName).FirstOrDefault();
            if (city==null)
            {
                return false;
            }
            else
                return true;
        }
        public CityLookUp? getByCityName(string name)
        {
            return dbContext.Set<CityLookUp>().Where(city=>city.CityName.Equals(name)).FirstOrDefault();
        }
    }
}
