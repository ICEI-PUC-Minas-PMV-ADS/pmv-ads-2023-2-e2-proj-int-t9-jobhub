﻿using JobHub.Models;
using Microsoft.EntityFrameworkCore;

namespace JobHub.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }

        public DbSet<Categoria> Categorias { get; set; } 
        public DbSet<Vaga> Vagas { get; set; }
    }
}
