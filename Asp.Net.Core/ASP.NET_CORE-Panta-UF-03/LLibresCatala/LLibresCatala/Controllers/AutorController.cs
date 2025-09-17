using LLibresCatala.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LLibresCatala.Models;
using LLibresCatala.ViewModels;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace LLibresCatala.Controllers
{
    public class AutorController : Controller
    {

        private readonly LlibresCatalaContext _contexte;

        public AutorController(LlibresCatalaContext contexte)
        {
            _contexte = contexte;
        }


        public async Task<IActionResult> Inici()
        {
            List<Persona> autors = new();

           // return View(autors);
            return View(await _contexte.persona.ToListAsync());
        }


        public ActionResult Detalls(int id)
        {
            AutorDetalls details = new(){Autor = new Persona(), Llibres = [] };
            return View(details);
        }


        //Això ja mostra el formulari correctamente. AQUÍ NO CAL FER RES. És l'altre el que heu de modificar.
        public ActionResult Nou()
        {
            return View(new AutorNou());
        }


        [HttpPost]
        public ActionResult Nou(AutorNou autorcreate)
        {
            return View(autorcreate);
        }


         public ActionResult Esborra(int id)
        {
            return RedirectToAction(nameof(Inici));
        }


        public ActionResult AssignaLlibre(int id)
        {
            AutorAssignaLlibre autorassignbook = new() { Autor = new Persona(), Llibres = [] };
            return View(autorassignbook);
        }


        public ActionResult AfegeixLlibre(int id, string isbn)
        {
            return RedirectToAction(nameof(Detalls), new {id = id});
        }


        //NO CAL FER-LA. NO ENTRA A L'EXÀMEN
        public ActionResult SuprimeixLlibre(int id, string isbn)
        {
            return Content("No implementat");
        }


    }
}
