using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingRoomsController : ControllerBase
    {
        private readonly IRoomService roomService;

        public MeetingRoomsController(IRoomService roomService)
        {
            this.roomService = roomService;
        }
        [HttpPost]
        public IActionResult Add([FromBody]RoomDto roomDto)
        {
            string response=roomService.AddRoom(roomDto);
            if (int.TryParse(response, out int id))
            {
                return Ok(response);
            }
            else
                return NotFound(response);
        }

    }
}
