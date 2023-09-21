using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Services.Implementations;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingLookUpsController : ControllerBase
    {
        private readonly IBuildingService service;

        public BuildingLookUpsController(IBuildingService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var list = service.GetAllBuildings();
            return Ok(list);
        }
        [HttpPost]
        public IActionResult Add([FromBody]BuildingDto buildingDto)
        {
                service.AddBuilding(buildingDto);
                return Ok();
 
        }
    }
}
