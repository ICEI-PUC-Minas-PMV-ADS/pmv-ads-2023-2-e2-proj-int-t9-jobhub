using JobHub.Models;
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
            vagasListViewModel.Categorias = _categoriaRepository.Categorias;

            ViewBag.TotalVagas = totalVagas;
            return View(vagasListViewModel);
        }

        public IActionResult CreateVaga()
        {
            return View();
        }

        [HttpPost]

        public IActionResult CreateVaga(Vaga Vaga )
        {  
            if(ModelState.IsValid)
            {
                _vagaRepository.AddVaga(Vaga);
                
                return RedirectToAction("List");
                    
            }


            return View(Vaga); 
        }

    }
}
