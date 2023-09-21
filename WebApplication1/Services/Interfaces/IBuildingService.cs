using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Services.Implementations
{
    public interface IBuildingService
    {
        int? GetBuildingId(string Name);
        string GetBuildingName(int id);
        IEnumerable<BuildingDto> GetAllBuildings();
        void AddBuilding(BuildingDto buildingDto);
        string GetBuildingAbbreviation(int facilityCityId);
    }
}
