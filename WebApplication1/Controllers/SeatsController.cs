using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Exceptions;
using WebApplication1.Models;
using WebApplication1.Services.Implementations;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/seats")]
    [ApiController]
    public class SeatsController : ControllerBase
    {
        private readonly ISeatService seatService;
        private readonly IAllocationService allocationService;

        public SeatsController(ISeatService seatService, IAllocationService allocationService)
        {
            this.seatService = seatService;
            this.allocationService = allocationService;
        }
        [HttpPost]
        public IActionResult Add([FromBody] SeatDto seatDto)
        {
            string message = seatService.AddSeats(seatDto);
            return Ok(message);

        }
        [HttpGet]
        public IActionResult Get([FromQuery] string? facilityId, bool? isFree)
        {

            return Ok(seatService.GetFreeSeats(facilityId, isFree));
        }
        [HttpGet("id")]
        public IActionResult GetSeatIdName([FromQuery] string seatName, int facilityId)
        {

            int seatId = seatService.GetSeatId(facilityId, seatName);
            return Ok(seatId);

        }
        [HttpPost("{id}/allocations")]
        public IActionResult Allocate(int id, [FromBody] AllocationDto allocationDto)
        {

            string message = allocationService.AddAllocation(id, allocationDto);
            return Ok(message);

        }
    }


}
