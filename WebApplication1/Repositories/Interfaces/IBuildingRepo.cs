﻿using WebApplication1.Models;

namespace WebApplication1.Repositories.Interfaces
{
    public interface IBuildingRepo
    {
        bool checkIfExists(BuildingLookUp buildingLookUp);
        BuildingLookUp? getByBuildingName(string name);
    }
}
