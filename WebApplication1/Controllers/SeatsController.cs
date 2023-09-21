using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Exceptions;
using WebApplication1.Models;
using WebApplication1.Services.Implementations;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatsController : ControllerBase
    {
        private readonly ISeatService seatService;
        private readonly IAllocationService allocationService;

        public SeatsController(ISeatService seatService,IAllocationService allocationService)
        {
            this.seatService = seatService;
            this.allocationService = allocationService;
        }
        [HttpPost]
        public IActionResult Add([FromBody] SeatDto seatDto)
        {
            try
            {
                string message = seatService.AddSeats(seatDto);
                return Ok(message);
            }
            catch(CustomException ex)
            {
                return NotFound(ex.Message);
            }
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
        [HttpGet("id")]
        public IActionResult GetSeatIdName([FromQuery] string seatName,int facilityId)
        {
            var seatId = seatService.GetSeatId(facilityId, seatName);

            if (seatId != null)
            {
                return Ok(seatId);
            }
            else
            {
                return NotFound("Seat not found"); // Return a 404 Not Found response if the seat is not found by name
            }
        }
        [HttpPost("{id}/allocations")]
        public IActionResult Allocate(int id, [FromBody] AllocationDto allocationDto)
        {
            string message = allocationService.AddAllocation(allocationDto);
            if (message == "allocated")
                return Ok(message);
            else
                return BadRequest(message);
        }
    }
    

}
