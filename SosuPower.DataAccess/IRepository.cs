using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SosuPower.DataAccess
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        T GetBy(int id);
    }

    public class Repository<T>: IRepository<T> where T : class
    {
        private readonly SosuPowerContext sosuPowerContext;

        public Repository(SosuPowerContext sosuPowerContext)
        {
            this.sosuPowerContext = sosuPowerContext;
        }

        public void Add(T entity)
        {
            sosuPowerContext.Add(entity);
            sosuPowerContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            sosuPowerContext.Remove(entity);
            sosuPowerContext.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return sosuPowerContext.Set<T>().ToList();
        }

        public T GetBy(int id)
        {
            return sosuPowerContext.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            sosuPowerContext.Update(entity);
        }
    }
}
