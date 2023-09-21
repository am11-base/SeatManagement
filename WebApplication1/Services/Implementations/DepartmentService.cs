using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IRepository<DepartmentLookup> repository;

        public DepartmentService(IRepository<DepartmentLookup> repository)
        {
            this.repository = repository;
        }
        public IEnumerable<DepartmentLookup> GetAllDepartments()
        {
            return repository.GetAll();
        }
        public bool CheckIfExists(int id)
        {
            var dept= repository.GetById(id);
            if(dept == null)
            {
                return false;
            }
            else
            { return true; }
        }

        public string GetDepartmentName(int departmentId)
        {
            return repository.GetById(departmentId).DepartmentName;
        }
    }
}
