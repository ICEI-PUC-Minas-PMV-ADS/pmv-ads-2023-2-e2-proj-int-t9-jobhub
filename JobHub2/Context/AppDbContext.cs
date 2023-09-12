using JobHub2.Models;
using Microsoft.EntityFrameworkCore;

namespace JobHub2.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }

        public DbSet<Categoria> Categorias { get; set; } 
    }
}
