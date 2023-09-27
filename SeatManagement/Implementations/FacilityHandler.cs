
using SeatManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebApplication1.DTOs;

namespace SeatManagement.Implementations
{
    
    public class FacilityHandler:IFacilityHandler
    {
        public async Task AddAsync()
        {
            string cityName,buildingName;
            Console.Clear();
            Console.WriteLine("\n \t Onboarding a facility");
            Console.WriteLine("-----------------------------------------------------------------------------");

            ICityHandler cityHandler= new CityHandler();
            await cityHandler.DisplayAllCitiesAsync();
            Console.Write("\n Add a new city?(yes/no) : ");
            string cityChoice=Console.ReadLine().ToLower();
            if(cityChoice.Equals("yes"))
            {
               cityName=await cityHandler.AddCityAsync();
            }
            else
            {
                Console.Write("\n Enter city Name of Facility : ");
                cityName=Console.ReadLine();
            }
            
            IBuildingHandler buildingHandler = new BuildingHandler();
            await buildingHandler.DisplayAllBuildingsAsync();
            Console.Write("\n Add a new Building?(yes/no) : ");
            string buildingChoice = Console.ReadLine().ToLower();
            if (buildingChoice.Equals("yes"))
            {
                buildingName=await buildingHandler.AddBuildingAsync();
            }
            else
            {
                Console.Write("\n Enter building Name of Facility : ");
                buildingName = Console.ReadLine();
            }
            Console.Write("\n Enter floor of facility : ");
            int floor=int.Parse(Console.ReadLine());

            Console.Write("\n Enter name of facility in the floor : ");
            string facilityName=Console.ReadLine();

            FacilityDto facility = new FacilityDto { BuildingName=buildingName,CityName=cityName,FacilityName=facilityName,Floor=floor};
            var json=JsonSerializer.Serialize<FacilityDto>(facility);

            HttpHandler httpHandler = HttpHandlerSingleton.GetInstance();
            await httpHandler.HttpPostAsync(json, "facilities");

        }
        public async Task DisplayAllAsync()
        {
            Console.WriteLine("\n Available Facilities");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            HttpHandler httpHandler = HttpHandlerSingleton.GetInstance();
            var json = await httpHandler.HttpGetAsync("facilities");
            if (json == null) return;
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var facilities = JsonSerializer.Deserialize<FacilityDto[]>(json, options);
            Console.WriteLine("| Facility ID |   City Name   | Building Name |  Floor  | Facility Name |");
            Console.WriteLine("-------------------------------------------------------------------------");

            foreach (var facility in facilities)
            {
                Console.WriteLine($"| {facility.FacilityId,-12} | {facility.CityName,-13} | {facility.BuildingName,-14} | {facility.Floor,-7} | {facility.FacilityName,-10} |");
            }

        }
    }
}
