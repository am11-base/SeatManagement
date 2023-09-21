using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagement.Interfaces
{
    public interface ISeatHandler
    {
        Task AddAsync();
        Task<int> PrintFreeSeatsAsync(int facilityId);
    }
}
