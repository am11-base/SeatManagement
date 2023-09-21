using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Services.Implementations;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CabinsController : ControllerBase
    {
        private readonly ICabinService cabinService;

        public CabinsController(ICabinService cabinService)
        {
            this.cabinService = cabinService;
        }
        [HttpPost]
        public IActionResult Add([FromBody]CabinDto cabinDto)
        {
            string message = cabinService.AddCabins(cabinDto);
            if (message == "Facility Not Found")
                return NotFound(message);
            else
                return Ok(message);
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
   
    }
}
