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
    
    public class BuildingHandler:IBuildingHandler
    {
        public async Task DisplayAllBuildingsAsync()
        {

            Console.WriteLine("\n Available Buildings");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~");

            HttpHandler httpHandler = HttpHandlerSingleton.GetInstance();
            var json = await httpHandler.HttpGetAsync("buildings");
            if (json == null) return;
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var buildings = JsonSerializer.Deserialize<BuildingDto[]>(json, options);
            foreach (var building in buildings)
            {
                Console.WriteLine($" {building.BuildingName}");

            }
        }
        public async Task<string?> AddBuildingAsync()
        {
            string buildingName, buildingAbbreviation;
            Console.Write("\n Enter building name : ");
            buildingName = Console.ReadLine();

            Console.Write(" Enter building Abbreviation : ");
            buildingAbbreviation = Console.ReadLine();

            BuildingDto building = new BuildingDto { BuildingAbbreviation = buildingAbbreviation!, BuildingName = buildingName! };
            var json = JsonSerializer.Serialize<BuildingDto>(building);

            HttpHandler httpHandler = HttpHandlerSingleton.GetInstance();
            await httpHandler.HttpPostAsync(json, "buildings");

            return buildingName;
        }
    }
}
