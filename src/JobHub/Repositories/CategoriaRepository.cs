using JobHub.Context;
using JobHub.Models;
using JobHub.Repositories.Interfaces;

namespace JobHub.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext contexto)
        {
            _context = contexto;
        }

        

        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}
