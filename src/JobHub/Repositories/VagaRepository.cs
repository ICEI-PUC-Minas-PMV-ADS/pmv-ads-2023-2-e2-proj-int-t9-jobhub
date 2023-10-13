﻿using JobHub.Context;
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

        public void CreateVaga(Vaga vaga)
        {
            
        }

        public void DeleteVaga(Vaga vaga)
        {
            throw new NotImplementedException();
        }

        public Vaga GetVagaById(int vagaId)
        {
            throw new NotImplementedException();
        }

        public void UpdateVaga(Vaga vaga)
        {
            throw new NotImplementedException();
        }
    }
}