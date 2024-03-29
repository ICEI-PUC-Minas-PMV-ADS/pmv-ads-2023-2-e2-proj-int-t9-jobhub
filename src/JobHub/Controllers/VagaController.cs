﻿using JobHub.Models;
using JobHub.Repositories;
using JobHub.Repositories.Interfaces;
using JobHub.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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
            vagasListViewModel.Vagas = _vagaRepository.Vagas.OrderByDescending(v => v.Id).ToList();
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
                    Text = c.Nome
                }).ToList();

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Empresa")]
        public IActionResult CreateVaga(Vaga Vaga)
        {
            if (ModelState.IsValid)
            {
                Vaga.EmpresaId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

                _vagaRepository.AddVaga(Vaga);

                return RedirectToAction("Index", "Home");

            }

            var categories = _categoriaRepository.Categorias.ToList();
            Console.WriteLine(categories.Count);

            ViewBag.Categorias = _categoriaRepository.Categorias
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Nome
                }).ToList();



            return View(Vaga);
        }

        public IActionResult Edit(int id)
        {
            var vaga = _vagaRepository.Vagas.FirstOrDefault(t => t.Id == id);

            if (vaga == null)
            {
                return NotFound();
            }

            var categorias = _categoriaRepository.Categorias.ToList();

            // Crie um modelo que combine a vaga e a lista de categorias
            var viewModel = new VagaEditViewModel
            {
                Vaga = vaga,
                Categorias = categorias
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(Vaga vaga)
        {
            if (ModelState.IsValid)
            {
                _vagaRepository.UpdateVaga(vaga);
                return RedirectToAction("Index", "Home");
            }

            var viewModel = new VagaEditViewModel
            {
                Vaga = vaga,
                Categorias = _categoriaRepository.Categorias.ToList()
            };
            return View("EditCategory", viewModel);
        }





        public IActionResult Delete(int id)
        {

            var vaga = _vagaRepository.Vagas.FirstOrDefault(t => t.Id == id);
            if (vaga == null)
            {
                return NotFound();
            }

            _vagaRepository.DeleteVaga(vaga);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost, ActionName("Delete")]

        public IActionResult DeleteConfirmed(Vaga vaga)
        {

            if (ModelState.IsValid)
            {
                _vagaRepository.DeleteVaga(vaga);
                return RedirectToAction("Index", "Home");
            }


            return View(vaga);
        }
        public IActionResult PaginaVaga(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaga = _vagaRepository.GetVagaById(id.Value); 

            if (vaga == null)
            {
                return NotFound();
            }

            ViewBag.Vaga = vaga;
            return View(vaga);
        }


    }
}
