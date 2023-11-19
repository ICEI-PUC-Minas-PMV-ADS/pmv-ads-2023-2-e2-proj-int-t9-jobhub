using JobHub.Models;

namespace JobHub.Repositories.Interfaces
{
    public interface IVagaRepository
    {
        IEnumerable<Vaga> Vagas { get; }
        Vaga GetVagaById(int vagaId);
        void AddVaga(Vaga vaga);
        void UpdateVaga(Vaga vaga);
        void DeleteVaga(Vaga vaga);
        void AddVaga(object vagaListViewModel);
        IEnumerable<Vaga> FiltrarVagas(string nome, string modo_trabalho, string senioridade);

    }
}
