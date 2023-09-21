using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomAmenityMappingsController : ControllerBase
    {
        private readonly IRoomAmenityMapService service;

        public RoomAmenityMappingsController(IRoomAmenityMapService service)
        {
            this.service = service;
        }
        [HttpPost]
        public IActionResult Add([FromBody]RoomAmenityMapDto roomAmenityMapDto)
        {
            service.AddMapping(roomAmenityMapDto);
            return Ok("mapping added");
        }
    }
}
