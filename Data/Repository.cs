using Microsoft.EntityFrameworkCore;
using ShoppingApp.Models;

namespace ShoppingApp.Data
{
    public class Repository : DbContext
    {
        public Repository(DbContextOptions<Repository> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> Types { get; set; }
    }
}
