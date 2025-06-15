using Microsoft.AspNetCore.Mvc;
using Validation_JQuery.Models.DataBase;
using Validation_JQuery.Models;

namespace Validation_JQuery.Controllers
{
    public class MembreController : Controller
    {
        public IActionResult Index()
        {
            return View(DB_Membres_Repository.ListeMembres);
        }
        // GET: Membre/Create
        public IActionResult Create()
        {
            return View(new Membre());
        }
        [HttpPost]
        public IActionResult Create(Membre membre)
        {
            if (ModelState.IsValid)
            {
                DB_Membres_Repository.ListeMembres.Add(membre);
                return RedirectToAction(nameof(Index));
            }
            return View(membre);
        }
    }
}
