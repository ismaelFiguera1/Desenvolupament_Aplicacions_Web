using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Examen.Data;

namespace Examen.Controllers
{
    public class TractamentsController : Controller
    {
        private readonly Context _context;

        public TractamentsController(Context context)
        {
            _context = context;
        }

        // GET: Tractaments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tractaments.ToListAsync());
        }

        // GET: Tractaments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tractament = await _context.Tractaments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tractament == null)
            {
                return NotFound();
            }

            return View(tractament);
        }

        // GET: Tractaments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tractaments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom")] Tractament tractament)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tractament);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tractament);
        }

        // GET: Tractaments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tractament = await _context.Tractaments.FindAsync(id);
            if (tractament == null)
            {
                return NotFound();
            }
            return View(tractament);
        }

        // POST: Tractaments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom")] Tractament tractament)
        {
            if (id != tractament.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tractament);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TractamentExists(tractament.Id))
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
            return View(tractament);
        }

        // GET: Tractaments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tractament = await _context.Tractaments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tractament == null)
            {
                return NotFound();
            }

            return View(tractament);
        }

        // POST: Tractaments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tractament = await _context.Tractaments.FindAsync(id);
            if (tractament != null)
            {
                _context.Tractaments.Remove(tractament);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TractamentExists(int id)
        {
            return _context.Tractaments.Any(e => e.Id == id);
        }
    }
}
