using SeatManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace SeatManagement.Implementations
{
   
    public class EmployeeHandler:IEmployeeHandler
    {
        public async Task AddAsync()
        {
            Console.Clear();
            Console.WriteLine("\n Add Employees");
            Console.WriteLine("--------------------------------------------------");

            Console.Write("\n Enter the number of employees to be added: ");
            int count=int.Parse(Console.ReadLine());

            IDepartmentHandler departmentHandler = new DepartmentHandler();
            await departmentHandler.PrintDepartmentAsync();

            List<EmployeeDto> listOfEmployees = new List<EmployeeDto>();

            for(int i=0;i<count;i++)
            {
                Console.WriteLine($"\n\n Enter the details of {i+1} employee");
                Console.Write("\n Enter Employee Name: ");
                string empName=Console.ReadLine();
                Console.Write("\n Enter department id: ");
                int deptId=int.Parse(Console.ReadLine());

                EmployeeDto employee = new EmployeeDto { DepartmentId = deptId, EmployeeName = empName };
                listOfEmployees.Add(employee);
                
            }
            var json = JsonSerializer.Serialize<List<EmployeeDto>>(listOfEmployees);
            HttpHandler httpHandler = HttpHandlerSingleton.GetInstance();
            await httpHandler.HttpPostAsync(json, "Employees");

        }
        public async Task DisplayAllAsync()
        {
            Console.WriteLine("Employee List");

            HttpHandler httpHandler = HttpHandlerSingleton.GetInstance();
            var employeeJson = await httpHandler.HttpGetAsync("Employees");
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var employees = JsonSerializer.Deserialize<EmployeeDto[]>(employeeJson, options);

            Console.WriteLine("+------------+---------------------+-----------------+");
            Console.WriteLine("| EmployeeID | Employee Name       | Department Name |");
            Console.WriteLine("+------------+---------------------+-----------------+");

            foreach (var employee in employees)
            {
                Console.WriteLine($"| {employee.EmployeeId,-11} | {employee.EmployeeName,-19} | {employee.DepartmentName,-15} |");
            }
        }
       
    }
}
