using SeatManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace SeatManagement.Implementations
{
   
    public class DepartmentHandler:IDepartmentHandler
    {
        public async Task PrintDepartmentAsync()
        {
            HttpHandler httpHandler = HttpHandlerSingleton.GetInstance();
            var departmentJson = await httpHandler.HttpGetAsync("Departments");
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var departments = JsonSerializer.Deserialize<DepartmentLookup[]>(departmentJson, options);

            Console.WriteLine("\n Department List\n");
            Console.WriteLine("+-------------+-------------------+");
            Console.WriteLine("| DepartmentId| DepartmentName    |");
            Console.WriteLine("+-------------+-------------------+");

            foreach (var department in departments)
            {
                Console.WriteLine($"| {department.DepartmentId,-12} | {department.DepartmentName,-17} |");
            }

        }
    }
}
