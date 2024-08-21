using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Shop.Domain.Models;

namespace WebStore.Shop.Business.Interfaces
{
    public interface IProductService
    {
        Product? Get(int id);
        IEnumerable<Product> Get();
        void Create(Product product);
        void Delete(int id);
    }
}
