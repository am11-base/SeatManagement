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
   
    public class ReportHandler:IReportHandler
    {
        public async Task ReportMenuAsync()
        {
            Console.Clear();
            Console.WriteLine("\n Report Generation");
            Console.WriteLine("-----------------------------------------------------------");

            Console.WriteLine("\n Select Filter");
            Console.WriteLine("\n 1. No filter");
            Console.WriteLine(" 2. By Facility");
            Console.WriteLine(" 3. By City");
            Console.WriteLine(" 4. By Floor");

            Console.Write(" Enter choice : ");
            int choice=int.Parse(Console.ReadLine());
            switch(choice)
            {
                case 1: await GenerateReportWithNoFilterAsync();
                    break;
                case 2: await GenerateReportOfFacilityAsync();
                    break;
                case 3:
                    await GenerateReportOfCityAsync();
                    break;
                case 4:
                    await GenerateReportOfFloorAsync();
                    break;
                default: Console.WriteLine("\n Wrong choice");
                    break;

            }
            
                
        }
        //change all the get according to rest api convention
        private async Task GenerateReportOfFloorAsync()
        {

            Console.Write("\n Enter floor : ");
            int floor =int.Parse(Console.ReadLine());

            HttpHandler httpHandler = HttpHandlerSingleton.GetInstance();
            var facilityJson = await httpHandler.HttpGetAsync($"Facilities?floor={floor}");
            if (facilityJson == null)
            {
                Console.WriteLine("\n floor don't exist");
                return;
            }

            else
            {
                await GenerateReportAsync(facilityJson);
            }


        }
        private async Task GenerateReportOfCityAsync()
        {
            ICityHandler cityHandler = new CityHandler();
            await cityHandler.DisplayAllCitiesAsync();

            Console.Write("\n Enter city Name: ");
            string cityName = Console.ReadLine();

            HttpHandler httpHandler = HttpHandlerSingleton.GetInstance();
            var facilityJson = await httpHandler.HttpGetAsync($"Facilities?city={cityName}");
            if (facilityJson == null)
            {
                Console.WriteLine("\n City don't exist");
                return;
            }
            
            else
            {
                await GenerateReportAsync(facilityJson);
            }


        }

        private async Task GenerateReportWithNoFilterAsync()
        {

            HttpHandler httpHandler = HttpHandlerSingleton.GetInstance();
            var facilityJson = await httpHandler.HttpGetAsync("Facilities");
            await GenerateReportAsync(facilityJson);
            
          
        }
        public async Task GenerateReportAsync(string facilityJson)
        {

            Console.Write("\n Generate report of free cabin/seat: ");
            string choice = Console.ReadLine().ToLower();
            HttpHandler httpHandler = HttpHandlerSingleton.GetInstance();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var facilities = JsonSerializer.Deserialize<FacilityDto[]>(facilityJson, options);


            if (choice.ToLower() == "seat")
            {
                List<FacilityAssetsDto<Seat>> allFreeSeatsData = new List<FacilityAssetsDto<Seat>>();
                foreach (var facility in facilities)
                {
                    var seatJson = await httpHandler.HttpGetAsync($"Seats?facilityId={facility.FacilityId.ToString()}&isFree=true");
                    var freeSeats = JsonSerializer.Deserialize<FacilityAssetsDto<Seat>>(seatJson, options);
                    allFreeSeatsData.Add(freeSeats);
                }
                Console.WriteLine("\n Free seats : \n");
                foreach (var facilityData in allFreeSeatsData)
                {
                    foreach (var seat in facilityData.Assets)
                    {
                        Console.WriteLine($" {seat.SeatName} ");
                    }
                }
            }
            else
            {
                List<FacilityAssetsDto<Cabin>> allFreeCabinsData = new List<FacilityAssetsDto<Cabin>>();

                foreach (var facility in facilities)
                {
                    var cabinJson = await httpHandler.HttpGetAsync($"Cabins?facilityId={facility.FacilityId.ToString()}&isFree=true");
                    var freeCabins = JsonSerializer.Deserialize<FacilityAssetsDto<Cabin>>(cabinJson, options);
                    allFreeCabinsData.Add(freeCabins);
                }
                Console.WriteLine("\n Free cabins : \n");
                foreach (var facilityData in allFreeCabinsData)
                {
                    foreach (var cabin in facilityData.Assets)
                    {
                        Console.WriteLine($" {cabin.CabinName} ");
                    }
                }
            }

        }
        public async Task GenerateReportOfFacilityAsync()
        {
           
            IFacilityHandler facilityHandler = new FacilityHandler();
            await facilityHandler.DisplayAllAsync();

            Console.Write("\n Select Facility id : ");
            int facilityId = int.Parse(Console.ReadLine());

            Console.Write("\n Generate report of free cabin/seat: ");
            string choice = Console.ReadLine().ToLower();

          //  IAllocationHandler allocationHandler = new AllocationHandler();
            if (choice.ToLower() == "cabin")
            {
                ICabinHandler cabinHandler = new CabinHandler();
                await cabinHandler.PrintFreeCabinsAsync(facilityId);
            }
                
            else
            {
                ISeatHandler seatHandler = new SeatHandler();
                await seatHandler.PrintFreeSeatsAsync(facilityId);
            }
                

        }
        
    }
}
