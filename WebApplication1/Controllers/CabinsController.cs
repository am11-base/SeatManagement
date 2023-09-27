using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Exceptions;
using WebApplication1.Services.Implementations;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/cabins")]
    [ApiController]
    public class CabinsController : ControllerBase
    {
        private readonly ICabinService cabinService;
        private readonly IAllocationService allocationService;

        public CabinsController(ICabinService cabinService, IAllocationService allocationService)
        {
            this.cabinService = cabinService;
            this.allocationService = allocationService;
        }
        [HttpPost]
        public IActionResult Add([FromBody] CabinDto cabinDto)
        {
            string message = cabinService.AddCabins(cabinDto);
            return Ok(message);

        }
        [HttpGet]
        public IActionResult Get([FromQuery] string? facilityId, bool? isFree)
        {

            return Ok(cabinService.GetFreeCabins(facilityId!, isFree));

        }
        [HttpGet("id")]
        public IActionResult GetCabinIdByName([FromQuery] string cabinName, int facilityId)
        {
            int? cabinId = cabinService.GetCabinId(facilityId, cabinName);
            return Ok(cabinId);

        }
        [HttpPost("{id}/allocations")]
        public IActionResult Allocate(int id, [FromBody] AllocationDto allocationDto)
        {
                string message = allocationService.AddAllocation(id, allocationDto);
                return Ok(message);
           
        }

    }
}
