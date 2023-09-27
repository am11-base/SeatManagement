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
    
    public class MeetingRoomHandler:IMeetingRoomHandler
    {
        public async Task AddAsync()
        {
            Console.Clear();
            Console.WriteLine("  Add Meeting Rooms");
            Console.WriteLine("-------------------------------------------------------");
            IFacilityHandler facilityHandler = new FacilityHandler();
            await facilityHandler.DisplayAllAsync();

            Console.Write("\n Choose the facility id to add meeting room : ");
            int facilityId = int.Parse(Console.ReadLine());

            Console.Write("\n Enter the number of chairs in room : ");
            int chairCount = int.Parse(Console.ReadLine());

            RoomDto room= new RoomDto { FacilityId = facilityId,numberOfChairs=chairCount };
            var json = JsonSerializer.Serialize<RoomDto>(room);
            HttpHandler httpHandler = HttpHandlerSingleton.GetInstance();
            var response=await httpHandler.HttpPostAsync(json, "meetingrooms");

            if (response!=null)
            {
                Console.WriteLine("\n Room Added");
                int roomId = int.Parse(response);
                var amenityJson = await httpHandler.HttpGetAsync("amenities");
                if (amenityJson == null) return;
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var amenities = JsonSerializer.Deserialize<Amenity[]>(amenityJson, options);


                foreach (var amenity in amenities)
                {
                    Console.Write($"\n Do the room has {amenity.AmenityName} (yes/no): ");
                    if (Console.ReadLine().ToLower().Equals("yes"))
                    {
                        await AddAmenityMappingAsync(amenity.AmenityId, roomId);
                    }

                }
            }
        }
        public async Task AddAmenityMappingAsync(int amenityId, int roomId)
        {
            //RoomAmenityMapDto roomAmenityMap = new RoomAmenityMapDto { AmenityId = amenityId, RoomId = roomId };
            //var json = JsonSerializer.Serialize<RoomAmenityMapDto>(roomAmenityMap);
            HttpHandler httpHandler = HttpHandlerSingleton.GetInstance();
            await httpHandler.HttpPostAsync(amenityId.ToString(), $"meetingrooms/{roomId}/amenities");
        }
    }
}
