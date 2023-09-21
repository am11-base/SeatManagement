using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> repository;
        private readonly IDepartmentService departmentService;

        public EmployeeService(IRepository<Employee> repository,IDepartmentService departmentService)
        {
            this.repository = repository;
            this.departmentService = departmentService;
        }
        public string AddEmployee(List<EmployeeDto> employeeDatas)
        {
            foreach (var employeeData in employeeDatas)
            {
                if (departmentService.CheckIfExists(employeeData.DepartmentId))
                {
                    Employee employee = new Employee { DepartmentId = employeeData.DepartmentId, EmployeeName = employeeData.EmployeeName };
                    repository.Add(employee);
                    
                }
            }
            return "Employees Added";
        }
        public IEnumerable<EmployeeDto> GetAll()
        {
            IEnumerable<EmployeeDto> employeeDatas=new List<EmployeeDto>();
            var employeeList=repository.GetAll();
            foreach (Employee employee in employeeList)
            {
                var deptName=departmentService.GetDepartmentName(employee.DepartmentId);
                employeeDatas = employeeDatas.Append(new EmployeeDto { DepartmentName = deptName, EmployeeName = employee.EmployeeName, EmployeeId = employee.EmployeeId });
            }
            return employeeDatas;
        }
        public bool CheckIfExists(int id)
        {
            var employee=repository.GetById(id);
            if(employee == null)
                return false;
            else
             return true; 
        }
        
    }
}
