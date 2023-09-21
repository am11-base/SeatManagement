using WebApplication1.Models;

namespace WebApplication1.Services.Interfaces
{
    public interface IDepartmentService
    {
        bool CheckIfExists(int id);
        IEnumerable<DepartmentLookup> GetAllDepartments();
        string GetDepartmentName(int departmentId);
    }
}
