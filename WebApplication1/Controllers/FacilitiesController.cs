using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Exceptions;
using WebApplication1.Services.Implementations;

namespace WebApplication1.Controllers
{
    [Route("api/facilities")]
    [ApiController]
    public class FacilitiesController : ControllerBase
    {
        private readonly IFacilityService service;

        public FacilitiesController(IFacilityService service)
        {
            this.service = service;
        }
        [HttpPost]
        public IActionResult OnBoard([FromBody] FacilityDto facilityDto)
        {
            var message = service.OnBoardFacility(facilityDto);
            return Ok(message);

        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] string? city = null, int? floor = null)
        {

            var listoffacilities = service.GetFacilities(city, floor);
            return Ok(listoffacilities);


        }

    }
}
