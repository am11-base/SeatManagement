using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Exceptions;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingRoomsController : ControllerBase
    {
        private readonly IRoomService roomService;
        private readonly IRoomAmenityMapService mappingService;

        public MeetingRoomsController(IRoomService roomService, IRoomAmenityMapService mappingService)
        {
            this.roomService = roomService;
            this.mappingService = mappingService;
        }
        [HttpPost]
        public IActionResult Add([FromBody] RoomDto roomDto)
        {
            try
            {
                string response = roomService.AddRoom(roomDto);
                return Ok(int.Parse(response));
            }
            catch(CustomException ex)
            {
                return NotFound(ex.Message);
            }
                
        }
        [HttpPost("{id}/amenities")]
        public IActionResult AmenityMapping(int id, [FromBody]int amenityId)
        {
            try
            {
                mappingService.AddMapping(id, amenityId);
                return Ok("mapping added");
            }
            catch(CustomException ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
