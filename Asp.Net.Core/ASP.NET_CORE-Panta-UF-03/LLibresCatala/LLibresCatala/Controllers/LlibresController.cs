using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LLibresCatala.Data;
using LLibresCatala.Models;

namespace LLibresCatala.Controllers
{
    public class LlibresController : Controller
    {
        private readonly LlibresCatalaContext _context;

        public LlibresController(LlibresCatalaContext context)
        {
            _context = context;
        }

        // GET: Llibres
        public async Task<IActionResult> Index()
        {
            return View(await _context.llibre.ToListAsync());
        }

        // GET: Llibres/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var llibre = await _context.llibre
                .FirstOrDefaultAsync(m => m.ISBN == id);
            if (llibre == null)
            {
                return NotFound();
            }

            return View(llibre);
        }

        // GET: Llibres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Llibres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ISBN,Titol,NumPag,Preu")] Llibre llibre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(llibre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(llibre);
        }

        // GET: Llibres/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var llibre = await _context.llibre.FindAsync(id);
            if (llibre == null)
            {
                return NotFound();
            }
            return View(llibre);
        }

        // POST: Llibres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ISBN,Titol,NumPag,Preu")] Llibre llibre)
        {
            if (id != llibre.ISBN)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(llibre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LlibreExists(llibre.ISBN))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(llibre);
        }

        // GET: Llibres/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var llibre = await _context.llibre
                .FirstOrDefaultAsync(m => m.ISBN == id);
            if (llibre == null)
            {
                return NotFound();
            }

            return View(llibre);
        }

        // POST: Llibres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var llibre = await _context.llibre.FindAsync(id);
            if (llibre != null)
            {
                _context.llibre.Remove(llibre);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LlibreExists(string id)
        {
            return _context.llibre.Any(e => e.ISBN == id);
        }
    }
}
