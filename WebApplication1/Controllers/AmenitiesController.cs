using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenitiesController : ControllerBase
    {
        private readonly IAmenityService amenityService;

        public AmenitiesController(IAmenityService amenityService)
        {
            this.amenityService = amenityService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(amenityService.GetAllAmenities());
        }
    }
}
