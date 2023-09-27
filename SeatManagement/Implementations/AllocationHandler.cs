using Microsoft.Extensions.Options;
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
    
    public class AllocationHandler:IAllocationHandler
    {
        public async Task AddAllocationAsync()
        {
            Console.Clear();
            Console.WriteLine("Add Allocation: ");
            Console.WriteLine("---------------------------");

            IEmployeeHandler employeeHandler = new EmployeeHandler();
            await employeeHandler.DisplayAllAsync();
            
            Console.Write("\n Enter employee id : ");
            int empId=int.Parse(Console.ReadLine());

            IFacilityHandler facilityHandler=new FacilityHandler();
            await facilityHandler.DisplayAllAsync();

            Console.Write("\n Select Facility id : ");
            int facilityId=int.Parse(Console.ReadLine());

            Console.Write("\n Allocate to cabin/seat: ");
            string choice=Console.ReadLine().ToLower();
            string assetName;

            HttpHandler httpHandler = HttpHandlerSingleton.GetInstance();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            AllocationDto allocationDto = new AllocationDto
            {
          
                AssetType = choice,
                EmployeeId = empId,
            };
           
            if (choice.ToLower() == "cabin")
            {
                ICabinHandler cabinHandler = new CabinHandler();
                int flag=await cabinHandler.PrintFreeCabinsAsync(facilityId);
                if (flag == -1)
                    return;
                Console.Write("\n Enter the cabin name to be allocated : ");
                assetName=Console.ReadLine();
                
                var json = await httpHandler.HttpGetAsync($"cabins/id?cabinName={assetName}&facilityId={facilityId}");
                if (json == null)
                    return;
                int cabinId = JsonSerializer.Deserialize<int>(json, options);
                var cabinJson = JsonSerializer.Serialize<AllocationDto>(allocationDto);
                await httpHandler.HttpPostAsync(cabinJson, $"cabins/{cabinId}/allocations");
            }
            else if(choice.ToLower()=="seat")
            {
                ISeatHandler seatHandler = new SeatHandler();
                int flag = await seatHandler.PrintFreeSeatsAsync(facilityId);
                if (flag == -1)
                    return;
                Console.Write("\n Enter the seat name to be allocated : ");
                assetName = Console.ReadLine();

                var json = await httpHandler.HttpGetAsync($"seats/id?seatName={assetName}&facilityId={facilityId}");

                if (json == null)
                    return;
                int seatId = JsonSerializer.Deserialize<int>(json, options);
                var seatJson = JsonSerializer.Serialize<AllocationDto>(allocationDto);
                await httpHandler.HttpPostAsync(seatJson, $"seats/{seatId}/allocations");

            }
            else
            {
                Console.WriteLine("\n wrong choice");
                return;
            }
            
            //var allocationJson=JsonSerializer.Serialize<AllocationDto>(allocationDto);
            //await httpHandler.HttpPostAsync(allocationJson, "AssetAllocations");
        }
        
        
        

    }
}
