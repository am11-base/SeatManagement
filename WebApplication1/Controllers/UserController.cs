using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Exceptions;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public IActionResult Login([FromBody]UserDto userDto)
        {
            try
            {
                var token=userService.Authenticate(userDto);
                return Ok(token);
            }
            catch (UnAuthorizeException ex)
            {
               return Unauthorized();
            }
        }
    }
}
