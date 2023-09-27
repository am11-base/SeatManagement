using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/employees")]
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
            return Ok(msg);

        }
        [HttpGet]
        public IActionResult Get([FromQuery] UserParam? userParam)
        {
            return Ok(service.GetAll(userParam));
        }
    }
}
