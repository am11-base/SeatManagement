using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService service;

        public EmployeesController(IEmployeeService service)
        {
            this.service = service;
        }

       

        [HttpPost]
        public IActionResult Add([FromBody]List<EmployeeDto> employees)
        {
            string msg=service.AddEmployee(employees);
            //change
            //TODO:
            if (msg.Equals("Department Not Found"))
                return NotFound(msg);
            else
                return Ok(msg);

        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(service.GetAll());
        }
    }
}
