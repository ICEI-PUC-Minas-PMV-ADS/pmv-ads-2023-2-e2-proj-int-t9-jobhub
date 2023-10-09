using JobHub.Models;

namespace JobHub.Repositories.Interfaces
{
    public interface IVagaRepository
    {
        IEnumerable<Vaga> Vagas { get; }
        Vaga GetVagaById(int vagaId);
        void CreateVaga(Vaga vaga);
        void UpdateVaga(Vaga vaga);
        void DeleteVaga(Vaga vaga);
    }
}
