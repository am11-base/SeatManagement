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
    
    public class CabinHandler:ICabinHandler
    {
        public async Task AddAsync()
        {
            Console.Clear();
            Console.WriteLine("  Add Cabins");
            Console.WriteLine("-------------------------------------------------------");
            IFacilityHandler facilityHandler = new FacilityHandler();
            await facilityHandler.DisplayAllAsync();

            Console.Write("\n Choose the facility id to add cabin : ");
            int facilityId = int.Parse(Console.ReadLine());

            Console.Write("\n Enter the number of cabin to be added : ");
            int cabinCount = int.Parse(Console.ReadLine());

            CabinDto cabin=new CabinDto { countOfCabins = cabinCount, FacilityId = facilityId };
            var json = JsonSerializer.Serialize<CabinDto>(cabin);
            HttpHandler httpHandler = HttpHandlerSingleton.GetInstance();
            await httpHandler.HttpPostAsync(json, "cabins");
        }
        public async Task<int> PrintFreeCabinsAsync(int facilityId)
        {

            HttpHandler httpHandler = HttpHandlerSingleton.GetInstance();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var cabinJson = await httpHandler.HttpGetAsync($"cabins?facilityId={facilityId.ToString()}&isFree=true");
            if (cabinJson == null) return -1;
            var freeCabins = JsonSerializer.Deserialize<FacilityAssetsDto<Cabin>>(cabinJson, options);
            if (freeCabins.FacilityId == -1)
            {
                Console.WriteLine("\n Facility don't exist");
                return -1;
            }
            else if (freeCabins.Assets.Count() == 0)
            {
                Console.WriteLine("\n ! No free cabins in facility");
                return -1;
            }

            Console.WriteLine("\n Available Cabins: ");
            foreach (var cabin in freeCabins.Assets)
            {
                Console.WriteLine($" {cabin.CabinName} ");
            }
            return 0;
        }
    }
}
