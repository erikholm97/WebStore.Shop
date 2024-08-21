using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Shop.Domain.Models;

namespace WebStore.Shop.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }
    }
}
