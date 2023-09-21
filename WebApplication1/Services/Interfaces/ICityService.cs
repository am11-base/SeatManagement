using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Services.Implementations
{
    public interface ICityService
    { 
        int? GetCityId(string Name);
        string GetCityName(int id);
        IEnumerable<CityDto> GetAllCities();
        void AddCity(CityDto cityDto);
        string GetCityAbbreviation(int facilityCityId);
    }
}
