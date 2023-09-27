using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Exceptions;
using WebApplication1.Services.Implementations;

namespace WebApplication1.Controllers
{
    [Route("api/cities")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
     
        private readonly ICityService service;

        public CitiesController(ICityService service)
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
             service.AddCity(cityDto);
             return Ok("city added");  
        }
    }
}
