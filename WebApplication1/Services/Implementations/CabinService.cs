using WebApplication1.DTOs;
using WebApplication1.Exceptions;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services.Implementations
{
    public class CabinService : ICabinService
    {
        private readonly IRepository<Cabin> repository;
        private readonly IFacilityService facilityService;
        private readonly ICabinRepo cabinRepo;

        public CabinService(IRepository<Cabin> repository, IFacilityService facilityService, ICabinRepo cabinRepo)
        {
            this.repository = repository;
            this.facilityService = facilityService;
            this.cabinRepo = cabinRepo;
        }
        public string AddCabins(CabinDto cabinData)
        {
            string message;
            if (!facilityService.CheckIfExists(cabinData.FacilityId))
            {
                throw new CustomException("facility not found");
            }
            else
            {
                var facilityAbbreviation = facilityService.GetFacilityAbbreviation(cabinData.FacilityId);
                for (int i = 0; i < cabinData.countOfCabins; i++)
                {
              
                    string cabinName = $"{facilityAbbreviation}-{GetCabinNumber(cabinData.FacilityId)}";
                    Cabin cabin = new Cabin { FacilityId = cabinData.FacilityId, CabinName = cabinName };
                    repository.Add(cabin);
                }
                return "Cabins Added";
            }
        }

        public FacilityAssetsDto<Cabin> GetFreeCabins(string facility)
        {
            int facilityId = int.Parse(facility);
            FacilityAssetsDto<Cabin> facilityAssetsDto = new FacilityAssetsDto<Cabin>();
            if (!facilityService.CheckIfExists(facilityId))
            {
                facilityAssetsDto.FacilityId = -1;

            }
            else
            {
               var listOfCabins = cabinRepo.GetFreeCabins(facilityId);

                facilityAssetsDto.FacilityId = facilityId;
                facilityAssetsDto.Assets = listOfCabins;
            }
            return facilityAssetsDto;

        }

        private string GetCabinNumber(int facilityId)
        {
            string lastCabin = cabinRepo.getLastAllocatedCabin(facilityId);
            if (lastCabin == null)
            {
                return "C001";
            }
            else
            {
                string numericPart = lastCabin.Substring(lastCabin.LastIndexOf("C") + 1);
                int number = int.Parse(numericPart);
                number++;
                return "C" + number.ToString("D3");
            }
        }
        public int GetCabinId(int facilityId,string name)
        {
            return cabinRepo.GetCabinId(facilityId,name);
        }
        public bool CheckIfAllocated(int cabinId)
        {
            return repository.GetById(cabinId).IsAssigned;
        }
        public void AllocateCabin(int cabinId)
        {
            var cabin = repository.GetById(cabinId);
            cabin.IsAssigned = true;
            repository.Update(cabin);
        }
    }
}
