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
    public class LlibrePersonasController : Controller
    {
        private readonly LlibresCatalaContext _context;

        public LlibrePersonasController(LlibresCatalaContext context)
        {
            _context = context;
        }

        // GET: LlibrePersonas
        public async Task<IActionResult> Index()
        {
            var llibresCatalaContext = _context.llibrepersona.Include(l => l.Llibre).Include(l => l.Persona);
            return View(await llibresCatalaContext.ToListAsync());
        }

        // GET: LlibrePersonas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var llibrePersona = await _context.llibrepersona
                .Include(l => l.Llibre)
                .Include(l => l.Persona)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (llibrePersona == null)
            {
                return NotFound();
            }

            return View(llibrePersona);
        }

        // GET: LlibrePersonas/Create
        public IActionResult Create()
        {
            ViewData["LlibreISBN"] = new SelectList(_context.llibre, "ISBN", "ISBN");
            ViewData["PersonaId"] = new SelectList(_context.persona, "Id", "Id");
            return View();
        }

        // POST: LlibrePersonas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,rol,primari,PersonaId,LlibreISBN")] LlibrePersona llibrePersona)
        {
            if (ModelState.IsValid)
            {
                _context.Add(llibrePersona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LlibreISBN"] = new SelectList(_context.llibre, "ISBN", "ISBN", llibrePersona.LlibreISBN);
            ViewData["PersonaId"] = new SelectList(_context.persona, "Id", "Id", llibrePersona.PersonaId);
            return View(llibrePersona);
        }

        // GET: LlibrePersonas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var llibrePersona = await _context.llibrepersona.FindAsync(id);
            if (llibrePersona == null)
            {
                return NotFound();
            }
            ViewData["LlibreISBN"] = new SelectList(_context.llibre, "ISBN", "ISBN", llibrePersona.LlibreISBN);
            ViewData["PersonaId"] = new SelectList(_context.persona, "Id", "Id", llibrePersona.PersonaId);
            return View(llibrePersona);
        }

        // POST: LlibrePersonas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,rol,primari,PersonaId,LlibreISBN")] LlibrePersona llibrePersona)
        {
            if (id != llibrePersona.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(llibrePersona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LlibrePersonaExists(llibrePersona.Id))
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
            ViewData["LlibreISBN"] = new SelectList(_context.llibre, "ISBN", "ISBN", llibrePersona.LlibreISBN);
            ViewData["PersonaId"] = new SelectList(_context.persona, "Id", "Id", llibrePersona.PersonaId);
            return View(llibrePersona);
        }

        // GET: LlibrePersonas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var llibrePersona = await _context.llibrepersona
                .Include(l => l.Llibre)
                .Include(l => l.Persona)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (llibrePersona == null)
            {
                return NotFound();
            }

            return View(llibrePersona);
        }

        // POST: LlibrePersonas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var llibrePersona = await _context.llibrepersona.FindAsync(id);
            if (llibrePersona != null)
            {
                _context.llibrepersona.Remove(llibrePersona);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LlibrePersonaExists(int id)
        {
            return _context.llibrepersona.Any(e => e.Id == id);
        }
    }
}
