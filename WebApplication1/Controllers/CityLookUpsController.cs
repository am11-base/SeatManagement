using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Services.Implementations;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityLookUpsController : ControllerBase
    {
     
        private readonly ICityService service;

        public CityLookUpsController(ICityService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Get() 
        {
            var list = service.GetAllCities();
            return Ok(list);
        }
        [HttpPost]
        public IActionResult Add([FromBody]CityDto cityDto)
        {
            try
            {
                service.AddCity(cityDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
