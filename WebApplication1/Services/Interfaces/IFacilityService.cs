using WebApplication1.DTOs;

namespace WebApplication1.Services.Implementations
{
    public interface IFacilityService
    {
        string OnBoardFacility(FacilityDto facilityDto);
        bool CheckIfExists(int id);
        IEnumerable<FacilityDto> GetAllFacilities();
        string GetFacilityAbbreviation(int id);
        IEnumerable<FacilityDto>? GetAllFacilitiesByCity(string city);
        IEnumerable<FacilityDto>? GetAllFacilitiesByFloor(int? floor);
    }
}
