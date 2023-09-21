using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;
using WebApplication1.Services.Implementations;

namespace WebApplication1.Services.Interfaces
{
    public class CityService:ICityService
    {
        private readonly IRepository<CityLookUp> repository;
        private readonly ICityRepo cityRepo;

        public CityService(IRepository<CityLookUp> repository,ICityRepo cityRepo)
        {
            this.repository = repository;
            this.cityRepo = cityRepo;
        }
 
        public int? GetCityId(string Name)
        {
            var city = cityRepo.getByCityName(Name);
            if (city == null)
                return null;
            else 
                return city.CityId;
        }

        public string GetCityName(int id)
        {
            return repository.GetById(id).CityName;
        }
        public IEnumerable<CityDto> GetAllCities()
        {
           var cities= repository.GetAll();
            return cities.Select(city => new CityDto{ CityName=city.CityName});
        }

        public void AddCity(CityDto cityDto)
        {
            CityLookUp cityLookUp = new CityLookUp { CityAbbreviation = cityDto.CityAbbreviation,CityName=cityDto.CityName };
            if (!cityRepo.checkIfExists(cityLookUp))
                repository.Add(cityLookUp);
        }

        public string GetCityAbbreviation(int facilityCityId)
        {
            return repository.GetById(facilityCityId).CityAbbreviation;
        }
    }
}
