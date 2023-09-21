using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;
using WebApplication1.Services.Implementations;

namespace WebApplication1.Services.Interfaces
{
    public class BuildingService : IBuildingService
    {
        private readonly IRepository<BuildingLookUp> repository;
        private readonly IBuildingRepo buildingRepo;

        public BuildingService(IRepository<BuildingLookUp> repository,IBuildingRepo buildingRepo)
        {
            this.repository = repository;
            this.buildingRepo = buildingRepo;
        }
        public int? GetBuildingId(string Name)
        {
            var building = buildingRepo.getByBuildingName(Name);
            if (building == null)
                return null;
            else
             return building.BuildingId;
        }

        public string GetBuildingName(int id) 
        {
            return repository.GetById(id).BuildingName;
        }
        public IEnumerable<BuildingDto> GetAllBuildings()
        {
            var buildings = repository.GetAll();
            return buildings.Select(building => new BuildingDto { BuildingName = building.BuildingName });
        }

        public void AddBuilding(BuildingDto buildingDto)
        {
            BuildingLookUp buildingLookUp = new BuildingLookUp { BuildingAbbreviation = buildingDto.BuildingAbbreviation,BuildingName = buildingDto.BuildingName };
            if (!buildingRepo.checkIfExists(buildingLookUp))
            {
                repository.Add(buildingLookUp);
            }
        }
        public string GetBuildingAbbreviation(int facilityCityId)
        {
            return repository.GetById(facilityCityId).BuildingAbbreviation;
        }
    }
}
