using JobHub.Context;
using JobHub.Models;
using JobHub.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JobHub.Repositories
{
    public class VagaRepository : IVagaRepository
    {
        private readonly AppDbContext _context;
        public VagaRepository(AppDbContext contexto)
        {
            _context = contexto;
        }
        public IEnumerable<Vaga> Vagas => _context.Vagas.Include(c => c.Categoria);

        public void AddVaga(Vaga vaga)
        {
            _context.Vagas.Add(vaga);
            _context.SaveChanges();
        }

        public void AddVaga(object vagaListViewModel)
        {
            _context.Vagas.Add((Vaga)vagaListViewModel);
        }

        public void DeleteVaga(Vaga vaga)
        {
            _context.Vagas.Remove(vaga);
            _context.SaveChanges() ;
        }

        public Vaga GetVagaById(int vagaId)
        {
            return _context.Vagas.Find(vagaId);
        }

        public void UpdateVaga(Vaga vaga)
        {
            _context.Entry(vaga).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<Vaga> BuscarPorNome(string nome)
        {
            IEnumerable<Vaga> vagas = _context.Vagas.Where(
                v => v.Titulo.ToUpper().Contains(nome.ToUpper())
            ).ToList();
            return vagas;
        }
    }
}
