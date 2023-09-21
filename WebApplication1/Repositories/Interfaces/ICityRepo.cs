using WebApplication1.Models;

namespace WebApplication1.Repositories.Interfaces
{
    public interface ICityRepo
    {
        bool checkIfExists(CityLookUp cityLookUp);
        CityLookUp? getByCityName(string name);
    }
}
