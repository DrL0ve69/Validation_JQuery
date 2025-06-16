using Microsoft.AspNetCore.Mvc;
using Validation_JQuery.Models.DataBase;
using Validation_JQuery.Models;

namespace Validation_JQuery.Controllers
{
    public class MembreController : Controller
    {
        private readonly IMembres_Repository _membresRepository;
        public MembreController(IMembres_Repository membresRepository)
        {
            _membresRepository = membresRepository;
        }
        public IActionResult Index()
        {
            return View(_membresRepository.ListeMembres);
        }
        // GET: Membre/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Membre membre)
        {
            if (ModelState.IsValid)
            {
                _membresRepository.AjouterMembre(membre);
                return RedirectToAction(nameof(Index));
            }
            return View(membre);
        }
        public IActionResult Supprimer(string username)
        {
            _membresRepository.SupprimerMembre(username);
            return RedirectToAction(nameof(Index),_membresRepository.ListeMembres);
        }
        // GET: Membre/Update/username
        public IActionResult Update(string username)
        {
            Membre membre = _membresRepository.GetMembre_Username(username);
            if (membre == null)
            {
                return NotFound();
            }
            return View(membre);
        }
        [HttpPost]
        public IActionResult Update(string username, Membre membre) 
        {
            if (ModelState.IsValid)
            {
                _membresRepository.ModifierMembre(username, membre);
                return RedirectToAction(nameof(Index), _membresRepository.ListeMembres);
            }
            return View(membre);
        }
    }
}
