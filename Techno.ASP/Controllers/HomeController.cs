using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Techno.ASP.Models;
using Techno.ASP.Models.Forms;
using Techno.ASP.Services;

namespace Techno.ASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Mailer _mailer;

        public HomeController(ILogger<HomeController> logger, Mailer mailer)
        {
            _logger = logger;
            _mailer = mailer;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactForm form)
        {
            if (ModelState.IsValid)
            {
                string subject = "Vous avez reçu un mail de " + form.Email;
                string content = $"<p>{form.Message}</p>";

                bool result = _mailer.Send("isabel.skou@yahoo.fr", subject, content);

                if (result)
                {
                    TempData["success"] = "Votre message a bien été envoyé";
                }
                else
                {
                    TempData["error"] = "Une erreur est survenue";
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(form);
            }

    }        

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
