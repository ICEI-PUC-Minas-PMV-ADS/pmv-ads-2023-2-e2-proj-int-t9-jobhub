using JobHub.Models;

namespace JobHub.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Vaga> Vagas { get; set; }
        public IEnumerable<Categoria> Categorias { get; set; }
        public string CategoriaAtual { get; set; }
    }
}
