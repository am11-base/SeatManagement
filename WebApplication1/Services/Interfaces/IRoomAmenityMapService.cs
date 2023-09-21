using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Services.Interfaces
{
    public interface IRoomAmenityMapService
    {
        public void AddMapping(int amenityId, int roomId);
    }
}
