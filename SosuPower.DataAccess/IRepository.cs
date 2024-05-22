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
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetBy(int id)
        {
            return sosuPowerContext.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
