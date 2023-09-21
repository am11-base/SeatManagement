using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatsController : ControllerBase
    {
        private readonly ISeatService seatService;

        public SeatsController(ISeatService seatService)
        {
            this.seatService = seatService;
        }
        [HttpPost]
        public IActionResult Add([FromBody] SeatDto seatDto)
        {
            string message=seatService.AddSeats(seatDto);
            if (message == "Facility Not Found")
                return NotFound(message);
            else
                return Ok(message);
        }
        [HttpGet]
        //change to single get add isfreeseats
        public IActionResult Get([FromQuery] string? facilityId,bool? isFree)
        {
            if(!string.IsNullOrEmpty(facilityId)&&isFree==true)
             return Ok(seatService.GetFreeSeats(facilityId));
            else
                return BadRequest();
        }
    }
    

}
