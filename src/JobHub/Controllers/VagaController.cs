using JobHub.Models;
using JobHub.Repositories;
using JobHub.Repositories.Interfaces;
using JobHub.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            ViewBag.Categorias = _categoriaRepository.Categorias
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Nome  // Assuming the property for category name is "Nome"
                }).ToList();

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

            var categories = _categoriaRepository.Categorias.ToList();
            Console.WriteLine(categories.Count);

            ViewBag.Categorias = _categoriaRepository.Categorias
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Nome  // Assuming the property for category name is "Name"
                }).ToList();



            return View(Vaga); 
        }

    }
}
