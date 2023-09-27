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
   
    public class SeatHandler:ISeatHandler
    {
        public async Task AddAsync()
        {
            Console.Clear();
            Console.WriteLine("  Add Seats");
            Console.WriteLine("-------------------------------------------------------");
            FacilityHandler facilityHandler = new FacilityHandler();
            await facilityHandler.DisplayAllAsync();

            Console.Write("\n Choose the facility id to add seats : ");
            int facilityId=int.Parse(Console.ReadLine());

            Console.Write("\n Enter the number of seats to be added : ");
            int seatCount=int.Parse(Console.ReadLine());

            SeatDto seat = new SeatDto { countOfSeats = seatCount ,FacilityId=facilityId};
            var json=JsonSerializer.Serialize<SeatDto>(seat);
            HttpHandler httpHandler = HttpHandlerSingleton.GetInstance();
            await httpHandler.HttpPostAsync(json, "Seats");
        }
        public async Task<int> PrintFreeSeatsAsync(int facilityId)
        {
            HttpHandler httpHandler = HttpHandlerSingleton.GetInstance();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var seatJson = await httpHandler.HttpGetAsync($"seats?facilityId={facilityId.ToString()}&isFree=true");
            if (seatJson == null) return -1;
            var freeSeats = JsonSerializer.Deserialize<FacilityAssetsDto<Seat>>(seatJson, options);
            if (freeSeats.FacilityId == -1)
            {
                Console.WriteLine("\n Facility don't exist");
                return -1;
            }
            else if (freeSeats.Assets.Count() == 0)
            {
                Console.WriteLine("\n ! No free seats in facility");
                return -1;
            }

            Console.WriteLine("\n Available Seats: ");
            foreach (var seat in freeSeats.Assets)
            {
                Console.WriteLine($" {seat.SeatName} ");
            }
            return 0;
        }
    }
}
