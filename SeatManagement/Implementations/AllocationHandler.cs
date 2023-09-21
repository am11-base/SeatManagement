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

            if (choice.ToLower() == "cabin")
            {
                ICabinHandler cabinHandler = new CabinHandler();
                int flag=await cabinHandler.PrintFreeCabinsAsync(facilityId);
                if (flag == -1)
                    return;
                Console.Write("\n Enter the cabin name to be allocated : ");
                assetName=Console.ReadLine();
                
            }
            else if(choice.ToLower()=="seat")
            {
                ISeatHandler seatHandler = new SeatHandler();
                int flag = await seatHandler.PrintFreeSeatsAsync(facilityId);
                if (flag == -1)
                    return;
                Console.Write("\n Enter the seat name to be allocated : ");
                assetName = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("\n wrong choice");
                return;
            }
            AllocationDto allocationDto = new AllocationDto
            {
                AssetName=assetName,
                AssetType=choice,
                EmployeeId=empId,
                FacilityId=facilityId,
            };
            var allocationJson=JsonSerializer.Serialize<AllocationDto>(allocationDto);
            await httpHandler.HttpPostAsync(allocationJson, "AssetAllocations");
        }
        
        
        

    }
}
