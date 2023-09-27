using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Services.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetAll(UserParam? param);
        string AddEmployee(List<EmployeeDto> employeeDatas);
        bool CheckIfExists(int id);
    }
}
