using WebApplication1.Data;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Repositories.Implementations
{
    public class EntityRepository<T> : IRepository<T> where T : class
    {
        private readonly SeatManagementDbContext dbContext;

        public EntityRepository(SeatManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Add(T entity)
        {
            dbContext.Set<T>().Add(entity);
            dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
           dbContext.Set<T>().Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
           return dbContext.Set<T>().ToList();
        }

        public T? GetById(int id)
        {
            return dbContext.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            dbContext.Entry(entity).State=Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}
