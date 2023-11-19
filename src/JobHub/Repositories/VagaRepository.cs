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

        public IEnumerable<Vaga> FiltrarVagas(string nome, string modo_trabalho, string senioridade)
        {
            IEnumerable<Vaga> vagas = _context.Vagas.Where(v => 
                (string.IsNullOrEmpty(nome) || v.Titulo.ToUpper().Contains(nome.ToUpper())) &&
                (string.IsNullOrEmpty(modo_trabalho) || v.FormaDeTrabalho.ToUpper().Equals(modo_trabalho.ToUpper())) &&
                (string.IsNullOrEmpty(senioridade) || v.Nivel.ToUpper().Equals(senioridade.ToUpper()))
            ).ToList();
            return vagas;
        }
    }
}
