using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Examen.Data;
using Examen.Models;

namespace Examen.Controllers
{
    public class PacientTractamentsController : Controller
    {
        private readonly Context _context;

        public PacientTractamentsController(Context context)
        {
            _context = context;
        }

        // GET: PacientTractaments
        public async Task<IActionResult> Index()
        {
            var context = _context.PacientTractament.Include(p => p.Pacient).Include(p => p.Tractament);
            return View(await context.ToListAsync());
        }

        // GET: PacientTractaments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacientTractament = await _context.PacientTractament
                .Include(p => p.Pacient)
                .Include(p => p.Tractament)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pacientTractament == null)
            {
                return NotFound();
            }

            return View(pacientTractament);
        }

        // GET: PacientTractaments/Create
        public IActionResult Create()
        {
            ViewData["PacientId"] = new SelectList(_context.Pacients, "Id", "Id");
            ViewData["TractamentId"] = new SelectList(_context.Tractaments, "Id", "Id");
            return View();
        }

        // POST: PacientTractaments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PacientId,TractamentId")] PacientTractament pacientTractament)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pacientTractament);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PacientId"] = new SelectList(_context.Pacients, "Id", "Id", pacientTractament.PacientId);
            ViewData["TractamentId"] = new SelectList(_context.Tractaments, "Id", "Id", pacientTractament.TractamentId);
            return View(pacientTractament);
        }

        // GET: PacientTractaments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacientTractament = await _context.PacientTractament.FindAsync(id);
            if (pacientTractament == null)
            {
                return NotFound();
            }
            ViewData["PacientId"] = new SelectList(_context.Pacients, "Id", "Id", pacientTractament.PacientId);
            ViewData["TractamentId"] = new SelectList(_context.Tractaments, "Id", "Id", pacientTractament.TractamentId);
            return View(pacientTractament);
        }

        // POST: PacientTractaments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PacientId,TractamentId")] PacientTractament pacientTractament)
        {
            if (id != pacientTractament.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pacientTractament);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacientTractamentExists(pacientTractament.Id))
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
            ViewData["PacientId"] = new SelectList(_context.Pacients, "Id", "Id", pacientTractament.PacientId);
            ViewData["TractamentId"] = new SelectList(_context.Tractaments, "Id", "Id", pacientTractament.TractamentId);
            return View(pacientTractament);
        }

        // GET: PacientTractaments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacientTractament = await _context.PacientTractament
                .Include(p => p.Pacient)
                .Include(p => p.Tractament)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pacientTractament == null)
            {
                return NotFound();
            }

            return View(pacientTractament);
        }

        // POST: PacientTractaments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pacientTractament = await _context.PacientTractament.FindAsync(id);
            if (pacientTractament != null)
            {
                _context.PacientTractament.Remove(pacientTractament);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacientTractamentExists(int id)
        {
            return _context.PacientTractament.Any(e => e.Id == id);
        }
    }
}
