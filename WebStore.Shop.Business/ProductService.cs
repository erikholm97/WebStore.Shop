using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Shop.Business.Interfaces;
using WebStore.Shop.Data.Interfaces;
using WebStore.Shop.Domain.Models;

namespace WebStore.Shop.Business
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> products;

        public ProductService(IRepository<Product> products)
        {
            this.products = products;
        }

        public void Create(Product product)
        {
           products.Create(product);
        }

        public void Delete(int id)
        {
            Product? productToDelete = Get(id) ?? throw new Exception("Product not found.");

            products.Delete(productToDelete);
        }

        public Product? Get(int id)
        {
            return products.GetAll().SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Product> Get()
        {
            return products.GetAll().ToList();
        }
    }
}
