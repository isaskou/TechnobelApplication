using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Techno.ASP.Models;
using Techno.ASP.Models.FormsModel;
using Techno.ASP.Services;

namespace Techno.ASP.Controllers
{
    public class SectionController : Controller
    {
        private readonly IServices<SectionModel, SectionForm> _service;

        public SectionController(IServices<SectionModel, SectionForm> service)
        {
            _service = service;
        }

        public IActionResult AllSections()
        {
            IEnumerable<SectionModel> models = _service.GetAll();
            return View(models);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SectionForm form)
        {
            if (ModelState.IsValid)
            {
                _service.Insert(form);
                TempData["success"] = "Une nouvelle filière a été créée";
                return RedirectToAction(nameof(AllSections));
            }
            else
            {
                TempData["error"] = "La filière n'a pas été créée, Veuillez recommencer";
                return View(form);
            }
        }

        public IActionResult Update(int id)
        {
            SectionForm form = _service.GetById(id);

            if (form == null)
            {
                return NotFound();
            }
            return View(form);
        }

        [HttpPost]
        public IActionResult Update(SectionForm form)
        {
            if (ModelState.IsValid)
            {
                _service.Update(form);
                TempData["success"] = "La filière a été mise à jour";
                return RedirectToAction(nameof(AllSections));
            }
            else
            {
                return View(form);
            }
        }

        public IActionResult Delete(int id)
        {
            if (_service.Delete(id))
            {
                TempData["success"] = "La filière à été supprimée";
            }
            else
            {
                TempData["error"] = "Une erreur est survenue, veuillez recommencer";
            }
            return RedirectToAction(nameof(AllSections));
        }
    }
}
