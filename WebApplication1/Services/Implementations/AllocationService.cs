using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services.Implementations
{
    public class AllocationService : IAllocationService
    {
        private readonly IRepository<AssetAllocation> repository;
        private readonly IEmployeeService employeeService;
        private readonly IAllocationRepo allocationRepo;
        private readonly ICabinService cabinService;
        private readonly ISeatService seatService;
        private readonly IAssetLookupService assetLookupService;

        public AllocationService(IRepository<AssetAllocation> repository, IEmployeeService employeeService, IAllocationRepo allocationRepo, ICabinService cabinService, ISeatService seatService, IAssetLookupService assetLookupService)
        {
            this.repository = repository;
            this.employeeService = employeeService;
            this.allocationRepo = allocationRepo;
            this.cabinService = cabinService;
            this.seatService = seatService;
            this.assetLookupService = assetLookupService;
        }
        public string AddAllocation(AllocationDto allocationDto)
        {
            string message;
            int assetId;

            int assetTypeId = assetLookupService.GetAssetId(allocationDto.AssetType);
            AssetAllocation allocation = new AssetAllocation();
            //
            if (!employeeService.CheckIfExists(allocationDto.EmployeeId))
            {
                message = "Employee don't exist";
                return message;
            }
            else
            {
                if (CheckIfEmployeeAllocated(allocationDto.EmployeeId))
                {
                    message = "Employee Already Allocated";
                    return message;
                }
                if (allocationDto.AssetType == "cabin")
                {
                    //check if cabin name exist and also cabin is not allocated
                    assetId = cabinService.GetCabinId(allocationDto.FacilityId, allocationDto.AssetName);
                    if (assetId == -1)
                    {
                        message = "Asset Not Exist";
                        return message;
                    }
                    else
                    {
                        bool status = cabinService.CheckIfAllocated(assetId);
                        if (status)
                        {
                            message = "Asset Already Allocated";
                            return message;
                        }
                        else
                        {
                            allocation.AssetId = assetId;
                            allocation.AssetTypeId = assetTypeId;
                            allocation.EmployeeId = allocationDto.EmployeeId;

                            cabinService.AllocateCabin(assetId);
                        }
                    }
                }
                else
                {
                    //check if seat name exist and also cabin is not allocated
                    assetId = seatService.GetSeatId(allocationDto.FacilityId, allocationDto.AssetName);
                    if (assetId == -1)
                    {
                        message = "Asset Not Exist";
                        return message;
                    }
                    else
                    {
                        bool status = seatService.CheckIfAllocated(assetId);
                        if (status)
                        {
                            message = "Asset Already Allocated";
                            return message;
                        }
                        else
                        {
                            allocation.AssetId = assetId;
                            allocation.AssetTypeId = assetTypeId;
                            allocation.EmployeeId = allocationDto.EmployeeId;
                            seatService.AllocateSeat(assetId);
                        }
                    }
                }
            }


            repository.Add(allocation);
            return "allocated";
        }
        public bool CheckIfEmployeeAllocated(int employeeId)
        {
            return allocationRepo.CheckIfEmployeeAllocated(employeeId);
        }
    }
}
