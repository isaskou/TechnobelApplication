using Microsoft.AspNetCore.Http;
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
    public class SkillController : Controller
    {
        private readonly IServices<SkillModel, SkillForm> _Service;

        public SkillController(IServices<SkillModel, SkillForm> service)
        {
            _Service = service;
        }


        // GET: SkillController
        public IActionResult AllSkills()
        {
            IEnumerable<SkillModel> models = _Service.GetAll();
            return View(models);
        }

        // GET: SkillController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SkillController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SkillController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken] - à remettre à la fin
        public IActionResult Create(SkillForm form)
        {
            if (ModelState.IsValid)
            {
                _Service.Insert(form);
                TempData["Success"] = "Bravo, vous avez créé un nouveau Skill";
                return RedirectToAction(nameof(AllSkills));
            }
            else
            {
                return View(form);
            }
        }

        // GET: SkillController/Edit/5
        public IActionResult Update(int id)
        {
            SkillForm form = _Service.GetById(id);

            if (form == null)
            {
                return NotFound();
            }
            return View(form);
        }

        // POST: SkillController/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Update(SkillForm form)
        {
            if (ModelState.IsValid)
            {
                _Service.Update(form);
                TempData["success"] = "Le skill a été modifié !";
                return RedirectToAction(nameof(AllSkills));
            }
            else
            {
                return View(form);
            }
        }

        // GET: SkillController/Delete/5
        public IActionResult Delete(int id)
        {
            if (_Service.Delete(id))
            {
                TempData["success"] = "Vous avez supprimé le skill";
            }
            else
            {
                TempData["error"] = "Quelque n'a pas fonctionné, le skill n'a pas été supprimé";
            }
            return RedirectToAction(nameof(AllSkills));
        }


    }
}
