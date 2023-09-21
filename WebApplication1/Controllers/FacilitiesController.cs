using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Services.Implementations;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilitiesController : ControllerBase
    {
        private readonly IFacilityService service;

        public FacilitiesController(IFacilityService service)
        {
            this.service = service;
        }
        [HttpPost]
        public IActionResult OnBoard([FromBody]FacilityDto facilityDto)
        {
            //[FromBody]Dictionary<string,string> inputData
            /*if(inputData != null)
            {
                FacilityDto facilityDto = new FacilityDto
                {
                    BuildingAbbreviation = inputData["BuildingAbbreviation"],
                    BuildingName = inputData["BuildingName"],
                    CityAbbreviation = inputData["CityAbbreviation"],
                    CityName = inputData["CityName"],
                    FacilityName = inputData["FacilityName"],
                };
            }*/
            var message=service.OnBoardFacility(facilityDto);
            if (message.Equals("City don't exist") || message.Equals("Building don't exist"))
                return NotFound(message);
            else
                return Ok(message);
        }
        //modify the get
        [HttpGet]
        public IActionResult GetAll([FromQuery] string? city=null,int? floor=null) 
        {
            if (!string.IsNullOrEmpty(city) && floor.HasValue)
                return BadRequest();
            else if (!string.IsNullOrEmpty(city))
            {
                var listOfFacilites = service.GetAllFacilitiesByCity(city);
                if (listOfFacilites == null)
                    return NotFound(null);
                else
                    return Ok(listOfFacilites);
            }
            else if(floor.HasValue)
            {
                var listOfFacilites = service.GetAllFacilitiesByFloor(floor);
                if (listOfFacilites == null)
                    return NotFound(null);
                else
                    return Ok(listOfFacilites);
            }
            else
            {
                var listOfFacilities = service.GetAllFacilities();
                return Ok(listOfFacilities);
            }
            //all facilities
            
        }
       
    }
}
