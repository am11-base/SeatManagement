using WebApplication1.DTOs;

namespace WebApplication1.Services.Implementations
{
    public interface IFacilityService
    {
        string OnBoardFacility(FacilityDto facilityDto);
        bool CheckIfExists(int id);
        string GetFacilityAbbreviation(int id);
        IEnumerable<FacilityDto>? GetFacilities(string? city, int? floor);
    }
}
