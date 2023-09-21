using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagement.Interfaces
{
    public interface IBuildingHandler
    {
        Task DisplayAllBuildingsAsync();
        Task<string?> AddBuildingAsync();
    }
}
