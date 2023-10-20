using JobHub.Models;
using JobHub.Repositories.Interfaces;
using JobHub.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JobHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVagaRepository _vagaRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        public HomeController(IVagaRepository vagaRepository, ICategoriaRepository categoriaRepository)
        {
            _vagaRepository = vagaRepository;
            _categoriaRepository = categoriaRepository;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Home Page";

            var homeIndexViewModel = new HomeIndexViewModel();
            homeIndexViewModel.Vagas = _vagaRepository.Vagas.OrderByDescending(v => v.Id).ToList();
            homeIndexViewModel.Categorias = _categoriaRepository.Categorias;

            return View(homeIndexViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}