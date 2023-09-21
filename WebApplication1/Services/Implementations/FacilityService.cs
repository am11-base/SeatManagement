using WebApplication1.Data;
using WebApplication1.DTOs;
using WebApplication1.Exceptions;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;
using WebApplication1.Services.Implementations;

namespace WebApplication1.Services.Interfaces
{
    public class FacilityService : IFacilityService
    {
        private readonly ICityService cityService;
        private readonly IBuildingService builidingService;
        private readonly IRepository<Facility> repository;

        public FacilityService(ICityService cityService,IBuildingService builidingService,IRepository<Facility> repository)
        {
            this.cityService = cityService;
            this.builidingService = builidingService;
            this.repository = repository;
          
        }
        public string OnBoardFacility(FacilityDto facilityDto)
        {
            string message;
            var cityId = cityService.GetCityId(facilityDto.CityName);
            if(cityId==null)
            {
                throw new CustomException("City don't exist");
                
            }
            var buildingId=builidingService.GetBuildingId(facilityDto.BuildingName);
            if (buildingId == null)
            {
                throw new CustomException("Building don't exist");
            }

            Facility facility = new Facility { FacilityBuildingId = (int)buildingId, FacilityCityId = (int)cityId, FacilityName = facilityDto.FacilityName, Floor = facilityDto.Floor };
            repository.Add(facility);
            return ("Facility Onboarded");
            
        }
        public IEnumerable<FacilityDto> GetAllFacilities()
        {
            IEnumerable<FacilityDto> facilityDtos = new List<FacilityDto>();
            var facilities = repository.GetAll();
            foreach(Facility facility in facilities)
            {
                var cityName = cityService.GetCityName(facility.FacilityCityId);
                var buildingName = builidingService.GetBuildingName(facility.FacilityBuildingId);
                facilityDtos=facilityDtos.Append(new FacilityDto { BuildingName = buildingName,CityName = cityName,FacilityName=facility.FacilityName,Floor=facility.Floor,FacilityId=facility.FacilityId });
                
            }
            return facilityDtos;
        
        }
        public IEnumerable<FacilityDto>? GetAllFacilitiesByCity(string city)
        {
            IEnumerable<FacilityDto> facilityDtos = new List<FacilityDto>();
            var cityId = cityService.GetCityId(city);
            if (cityId == null)
                return null;
            
            var facilities = repository.GetAll().Where(facility=>facility.FacilityCityId==cityId);
            foreach (Facility facility in facilities)
            {
                var cityName = cityService.GetCityName(facility.FacilityCityId);
                var buildingName = builidingService.GetBuildingName(facility.FacilityBuildingId);
                facilityDtos = facilityDtos.Append(new FacilityDto { BuildingName = buildingName, CityName = cityName, FacilityName = facility.FacilityName, Floor = facility.Floor, FacilityId = facility.FacilityId });

            }
            return facilityDtos;

        }
        public string GetFacilityAbbreviation(int id)
        {
            string abbreviation;
            var facility = repository.GetById(id);
            var cityAbbreviation = cityService.GetCityAbbreviation(facility.FacilityCityId);
            var buildingAbbreviation = builidingService.GetBuildingAbbreviation(facility.FacilityBuildingId);
            abbreviation = $"{cityAbbreviation}-{buildingAbbreviation}-{facility.Floor}-{facility.FacilityName}";
            return abbreviation;
        }
        public bool CheckIfExists(int id)
        {
            if (repository.GetById(id) == null)
                return false;
            else 
                return true;
        }

        public IEnumerable<FacilityDto>? GetAllFacilitiesByFloor(int? floor)
        {
            IEnumerable<FacilityDto> facilityDtos = new List<FacilityDto>();

            var facilities = repository.GetAll().Where(facility => facility.Floor==floor);
            if (facilities.Count() == 0)
                return null;
            foreach (Facility facility in facilities)
            {
                var cityName = cityService.GetCityName(facility.FacilityCityId);
                var buildingName = builidingService.GetBuildingName(facility.FacilityBuildingId);
                facilityDtos = facilityDtos.Append(new FacilityDto { BuildingName = buildingName, CityName = cityName, FacilityName = facility.FacilityName, Floor = facility.Floor, FacilityId = facility.FacilityId });

            }
            return facilityDtos;
        }
    }
}
