using WebApplication1.DTOs;
using WebApplication1.Exceptions;
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
        public string AddAllocation(int assetId, AllocationDto allocationDto)
        {
            AssetAllocation allocation = new AssetAllocation();

            int? assetTypeId = assetLookupService.GetAssetId(allocationDto.AssetType);
            if (assetTypeId == null)
                throw new NotFoundException("AssetType don't exist");


            if (!employeeService.CheckIfExists(allocationDto.EmployeeId))
            {
                throw new NotFoundException("Employee don't exist");
            }
            else
            {
                if (CheckIfEmployeeAllocated(allocationDto.EmployeeId))
                {
                    throw new BadRequestException("Employee Already Allocated");
                }
                if (allocationDto.AssetType == "cabin")
                {
                    //add logic to check if id exist
                    bool isCabinExist = cabinService.CheckIfExists(assetId);
                    if (!isCabinExist)
                        throw new NotFoundException("cabin not exist");
                    //check if cabin is already allocated
                    bool isCabinAllocated = cabinService.CheckIfAllocated(assetId);
                    if (isCabinAllocated)
                    {
                        throw new BadRequestException("Asset Already Allocated");
                    }
                    else
                    {
                        allocation.AssetId = assetId;
                        allocation.AssetTypeId = (int)assetTypeId;
                        allocation.EmployeeId = allocationDto.EmployeeId;

                        cabinService.AllocateCabin(assetId);
                    }

                }
                else
                {
                    //check if seat id exist
                    bool isSeatExist = seatService.CheckIfExists(assetId);
                    if (!isSeatExist)
                        throw new NotFoundException("seat not exist");

                    //check if seat is allocated

                    bool isSeatAllocated = seatService.CheckIfAllocated(assetId);
                    if (isSeatAllocated)
                    {
                        throw new BadRequestException("Asset Already Allocated");
                    }
                    else
                    {
                        allocation.AssetId = assetId;
                        allocation.AssetTypeId = (int)assetTypeId;
                        allocation.EmployeeId = allocationDto.EmployeeId;
                        seatService.AllocateSeat(assetId);
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
