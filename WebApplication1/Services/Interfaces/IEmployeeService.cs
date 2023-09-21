using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Services.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetAll();
        string AddEmployee(EmployeeDto employee);
        bool CheckIfExists(int id);
    }
}
