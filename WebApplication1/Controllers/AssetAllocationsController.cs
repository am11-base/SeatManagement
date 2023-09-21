using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetAllocationsController : ControllerBase
    {
        private readonly IAllocationService allocationService;

        public AssetAllocationsController(IAllocationService allocationService) 
        {
            this.allocationService = allocationService;
        }
        [HttpPost]
        public IActionResult Add([FromBody]AllocationDto allocationDto)
        {
            string message=allocationService.AddAllocation(allocationDto);
            if (message == "allocated")
                return Ok(message);
            else
                return BadRequest(message);
        }
    }
}
