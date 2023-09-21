using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Exceptions;
using WebApplication1.Services.Implementations;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CabinsController : ControllerBase
    {
        private readonly ICabinService cabinService;
        private readonly IAllocationService allocationService;

        public CabinsController(ICabinService cabinService,IAllocationService allocationService)
        {
            this.cabinService = cabinService;
            this.allocationService = allocationService;
        }
        [HttpPost]
        public IActionResult Add([FromBody]CabinDto cabinDto)
        {
            try
            {
                string message = cabinService.AddCabins(cabinDto);
                return Ok(message);
            }
            catch(CustomException ex)
            {
                return NotFound(ex.Message);
            }
                
        }
        //change this to get add isfreecabins=1 modify!!!!
        [HttpGet]
        public IActionResult Get([FromQuery] string? facilityId, bool? isFree)
        {
            if (!string.IsNullOrEmpty(facilityId) && isFree==true)
                return Ok(cabinService.GetFreeCabins(facilityId));
            else
                return BadRequest();
        }
        [HttpGet("id")]
        public IActionResult GetCabinIdByName([FromQuery] string cabinName, int facilityId)
        {
            var cabinId = cabinService.GetCabinId(facilityId, cabinName);

            if (cabinId != null)
            {
                return Ok(cabinId);
            }
            else
            {
                return NotFound("Cabin not found"); // Return a 404 Not Found response if the seat is not found by name
            }
        }
        [HttpPost("{id}/allocations")]
        public IActionResult Allocate(int id, [FromBody] AllocationDto allocationDto)
        {
            string message = allocationService.AddAllocation(allocationDto);
            if (message == "allocated")
                return Ok(message);
            else
                return BadRequest(message);
        }

    }
}
