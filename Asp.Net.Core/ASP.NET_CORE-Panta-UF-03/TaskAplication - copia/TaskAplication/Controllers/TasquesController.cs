using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TaskAplication.Data;
using TaskAplication.Models;

namespace TaskAplication.Controllers
{
    public class TasquesController : Controller
    {


        public ApplicationContext _context;

        public TasquesController(ApplicationContext context)
        {
            _context = context;
        }




        [HttpGet]
        public IActionResult Index()
        {
            var tasques = _context.Tasks.ToList();
            return View(tasques);
        }

        [HttpPost]
        public IActionResult Esborrar(int idForm)
        {
         //   var tasca = _context.Tasks.Find(idForm);
               var tasca = _context.Tasks.FirstOrDefault(tasca => tasca.Id == idForm);
         //    var llista = _context.Tasks.Where(tasca => tasca.TascaFeta == true).ToList();
            if (tasca != null)
            {
                _context.Tasks.Remove(tasca);
                _context.SaveChanges();
                TempData["Message"] = "Tasca esborrada";
            }
            else
            {
                TempData["Message"] = "No s'ha pogut esborrar la tasca";
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Alta()
        {
            var tasca = new Tasca();
            return View("NewTask", tasca);
        }


        [HttpPost]
        public IActionResult Alta(Tasca task)
        {


            if (!ModelState.IsValid)
            {
                return View("NewTask", task);
            }

            _context.Tasks.Add(task);
            _context.SaveChanges();



            TempData["Message"] = "Alta feta correctament";

            return RedirectToAction("Alta");
        }



        [HttpPost]
        public IActionResult UpdateGet(int id)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.Id == id);

            return View("Update", task);
        }



        [HttpPost]
        public IActionResult Update(Tasca task, DateTime dataCreation)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", task);
            }

            _context.Tasks.Update(task);
            task.CrearModificar = dataCreation;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
