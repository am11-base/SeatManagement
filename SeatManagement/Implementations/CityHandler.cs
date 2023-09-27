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
    
    public class CityHandler:ICityHandler
    {
        public async Task DisplayAllCitiesAsync()
        {

            Console.WriteLine("\n Available Cities");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~");

            HttpHandler httpHandler = HttpHandlerSingleton.GetInstance();
            var json = await httpHandler.HttpGetAsync("cities");
            if (json == null) return;
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var cities = JsonSerializer.Deserialize<CityDto[]>(json, options);
            foreach (var city in cities)
            {
                Console.WriteLine($" {city.CityName}");

            }
        }
        //WTF
        public async Task<string?> AddCityAsync()
        {
            string cityName, cityAbbreviation;
            Console.Write("\n Enter city name : ");
            cityName=Console.ReadLine();

            Console.Write(" Enter city Abbreviation : ");
            cityAbbreviation=Console.ReadLine();

            CityDto city = new CityDto { CityAbbreviation = cityAbbreviation, CityName = cityName };
            var json = JsonSerializer.Serialize<CityDto>(city);

            HttpHandler httpHandler=HttpHandlerSingleton.GetInstance();
            await httpHandler.HttpPostAsync(json, "cities");

            return cityName;
        }
    }
}
