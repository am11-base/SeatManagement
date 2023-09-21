using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Repositories.Implementations
{
    public class BuildingLookUpRepo : EntityRepository<BuildingLookUp>,IBuildingRepo
    {
        private readonly SeatManagementDbContext dbContext;

        public BuildingLookUpRepo(SeatManagementDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool checkIfExists(BuildingLookUp buildingLookUp)
        {
            var building = dbContext.Set<BuildingLookUp>().Where(building=>building.BuildingName==buildingLookUp.BuildingName).FirstOrDefault();
            if (building == null)
            {
                return false;
            }
            else
                return true;
        }
        public BuildingLookUp? getByBuildingName(string name)
        {
            return dbContext.Set<BuildingLookUp>().Where(building => building.BuildingName.Equals(name)).FirstOrDefault();
        }
    }
}
