﻿using WebApplication1.DTOs;

namespace WebApplication1.Services.Interfaces
{
    public interface IAllocationService
    {
        string AddAllocation(int id, AllocationDto allocationDto);
    }
}
