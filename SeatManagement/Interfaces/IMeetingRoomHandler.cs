using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagement.Interfaces
{
    public interface IMeetingRoomHandler
    {
        Task AddAsync();
        Task AddAmenityMappingAsync(int amenityId, int roomId);
    }
}
