using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Techno.ASP.Models;
using Techno.ASP.Models.Forms;
using Techno.ASP.Models.FormsModel;
using Techno.ASP.Services;

namespace Techno.ASP.Controllers
{
    
    public class ProfileController : Controller
    {

        private readonly IServices<ProfileModel, ProfileForm> _service;
        private readonly IServices<SectionModel, SectionForm> _sectionServices;

        public ProfileController(IServices<ProfileModel, ProfileForm> service, 
                                IServices<SectionModel, SectionForm> sectionServices)
        {
            _service = service;
            _sectionServices = sectionServices;
        }

        public IActionResult AllProfiles()
        {
            IEnumerable<ProfileModel> model = _service.GetAll();
            return View(model);
        }

        //Get
        public IActionResult Create(int id)
        {
            ProfileForm form = new ProfileForm(_sectionServices)
            {
                UserId = id
            };

            return View(form);
        }

        //Post
        [HttpPost]
        //[ValidateAntiForgeryToken] - à remettre à la fin
        public IActionResult Create(ProfileForm form)
        {
            //pour éviter le pattern ServiceLocateur
            // on injecte directement le service via la propriété du ProfileForm
            form.SectionService = _sectionServices;

            if (ModelState.IsValid)
            {
                string[] typeAuthorize = { "image/jpeg", "image/jpg", "image/png", "image/gif" };
                byte[] imageEnByte = null;
                //1. Checker le fihier
                //1.1 Est - ce qu'on a un fichier?
                if (form.ImageFile != null)
                {
                    //1.2 la taille est-elle correcte?
                    if (form.ImageFile.Length > 10000000)
                    {
                        TempData["error"] = "image trop lourde";
                        return View(form);
                    }

                    //1.3. Est - ce une image?
                    if (!typeAuthorize.Contains(form.ImageFile.ContentType))
                    {
                        TempData["error"] = "le format de l'image n'est pas autorisé";
                        return View(form);
                    }

                }

                _service.Insert(form);
                TempData["Success"] = "Bravo, vous avez créé un nouveau Profil";
                return RedirectToAction(nameof(AllProfiles));

            }
            else
            {
                return View(form);
            }
        }

    }
}
