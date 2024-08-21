using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Shop.Data.Interfaces;

namespace WebStore.Shop.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext context;

        public Repository(DataContext context)
        {
            this.context = context;
        }

        public void Create(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            context.Remove(entity);
            context.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return context.Set<T>();
        }
    }
}
