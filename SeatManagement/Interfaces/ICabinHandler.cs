using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagement.Interfaces
{
    public interface ICabinHandler
    {
        Task AddAsync();
        Task<int> PrintFreeCabinsAsync(int facilityId);
    }
}
