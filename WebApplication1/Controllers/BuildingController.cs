using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Services.Implementations;

namespace WebApplication1.Controllers
{
    [Route("api/buildings")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingService service;

        public BuildingController(IBuildingService service)
        {
            this.service = service;
        }

        [HttpGet]
        //[Authorize(Roles ="admin")]
        public IActionResult Get()
        {
            var list = service.GetAllBuildings();
            return Ok(list);
        }
        [HttpPost]
        public IActionResult Add([FromBody]BuildingDto buildingDto)
        {
                service.AddBuilding(buildingDto);
                return Ok("building added");
 
        }
    }
}
