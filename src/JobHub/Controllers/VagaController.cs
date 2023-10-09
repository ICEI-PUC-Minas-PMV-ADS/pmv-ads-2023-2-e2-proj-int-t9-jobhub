using JobHub.Repositories;
using JobHub.Repositories.Interfaces;
using JobHub.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JobHub.Controllers
{
    public class VagaController : Controller
    {
        private readonly IVagaRepository _vagaRepository;
        private readonly ICategoriaRepository _categoriaRepository;


        public VagaController(IVagaRepository vagaRepository, ICategoriaRepository categoriaRepository)
        {
            _vagaRepository = vagaRepository;
            _categoriaRepository = categoriaRepository;
        }

        public IActionResult List()
        {
            ViewData["Title"] = "Lista de Vagas";

            var vagasListViewModel = new VagaListViewModel();
            vagasListViewModel.Vagas = _vagaRepository.Vagas;
            var totalVagas = vagasListViewModel.Vagas.Count();
            vagasListViewModel.CategoriaAtual = "Front-end";
            vagasListViewModel.Categorias = _categoriaRepository.Categorias;

            ViewBag.TotalVagas = totalVagas;
            return View(vagasListViewModel);
        }
    }
}
