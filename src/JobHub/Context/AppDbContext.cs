using JobHub.Models;
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
        public DbSet<VagaCandidato> VagaCandidatos { get; set; }

        public  DbSet<Usuario> Usuarios { get; set; }
        public  DbSet<Empresa> Empresas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empresa>()
                .HasMany(e => e.VagasCriadas)
                .WithOne(v => v.EmpresaVaga)
                .HasForeignKey(v => v.EmpresaId);

            modelBuilder.Entity<VagaCandidato>()
                .HasKey(vc => new { vc.CandidatoId, vc.VagaId });

            modelBuilder.Entity<VagaCandidato>()
                .HasOne(vc => vc.Candidato)
                .WithMany(c => c.VagasAplicadas)
                .HasForeignKey(vc => vc.CandidatoId);

            modelBuilder.Entity<VagaCandidato>()
                .HasOne(vc => vc.Vaga)
                .WithMany(v => v.CandidatosAplicados)
                .HasForeignKey(vc => vc.VagaId);

        }
    }
}
