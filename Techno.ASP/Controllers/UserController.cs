using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Techno.ASP.Models;
using Techno.ASP.Models.Forms;
using Techno.ASP.Services;

namespace Techno.ASP.Controllers
{
    public class UserController : Controller
    {
        private readonly IServices<UserModel, UserForm> _service;

        public UserController(IServices<UserModel, UserForm> service)
        {
            _service = service;
        }

        public IActionResult AllUsers()
        {
            IEnumerable<UserModel> model = _service.GetAll();
            return View(model);
        }

        //GET 
        public IActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        //[ValidateAntiForgeryToken] - à remettre à la fin
        public IActionResult Create(UserForm form)
        {
            if (ModelState.IsValid)
            {
                _service.Insert(form);
                TempData["Success"] = "Bravo, vous avez créé un nouveau User";
                return RedirectToAction("Create", "Profile", new
                {
                    id = form.Id
                }) ;
            }
            else
            {
                TempData["error"] = "Formulaire invalide";
                return View(form);
            }
        }

        //GET
        public IActionResult Update(int id)
        {
            UserForm form = _service.GetById(id);
            
            if (form == null)
            {
                return NotFound();
            }
            return View(form);
        }

        //POST
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Update(UserForm form)
        {
            if(ModelState.IsValid)
            {
                _service.Update(form);
                TempData["success"] = "Le user a été modifié";
                return RedirectToAction(nameof(AllUsers));
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
                TempData["success"] = "Vous avez supprimé le user";

            }
            else
            {
                TempData["error"] = "Quelquechose n'a pas fonctionné, le user n'a pas été supprimé";
            }
            return RedirectToAction(nameof(AllUsers));

        }
    }
}
