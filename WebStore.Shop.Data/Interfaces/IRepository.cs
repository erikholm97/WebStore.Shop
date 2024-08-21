using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Shop.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        void Delete(T entity);
        void Create(T entity);
    }
}
