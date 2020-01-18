using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SBD_Projekt.Models;

namespace SBD_Projekt.Controllers
{
    public class SpecjalizacjasController : Controller
    {
        private readonly SBD_ProjektContext _context;

        public SpecjalizacjasController(SBD_ProjektContext context)
        {
            _context = context;
        }

        // GET: Specjalizacjas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Specjalizacja.ToListAsync());
        }

        // GET: Specjalizacjas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specjalizacja = await _context.Specjalizacja
                .FirstOrDefaultAsync(m => m.id_specjalizacja == id);
            if (specjalizacja == null)
            {
                return NotFound();
            }

            return View(specjalizacja);
        }

        // GET: Specjalizacjas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Specjalizacjas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_specjalizacja,nazwa,doswiadczenie")] Specjalizacja specjalizacja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(specjalizacja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(specjalizacja);
        }

        // GET: Specjalizacjas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specjalizacja = await _context.Specjalizacja.FindAsync(id);
            if (specjalizacja == null)
            {
                return NotFound();
            }
            return View(specjalizacja);
        }

        // POST: Specjalizacjas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_specjalizacja,nazwa,doswiadczenie")] Specjalizacja specjalizacja)
        {
            if (id != specjalizacja.id_specjalizacja)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(specjalizacja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecjalizacjaExists(specjalizacja.id_specjalizacja))
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
            return View(specjalizacja);
        }

        // GET: Specjalizacjas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specjalizacja = await _context.Specjalizacja
                .FirstOrDefaultAsync(m => m.id_specjalizacja == id);
            if (specjalizacja == null)
            {
                return NotFound();
            }

            return View(specjalizacja);
        }

        // POST: Specjalizacjas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var specjalizacja = await _context.Specjalizacja.FindAsync(id);
            _context.Specjalizacja.Remove(specjalizacja);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpecjalizacjaExists(int id)
        {
            return _context.Specjalizacja.Any(e => e.id_specjalizacja == id);
        }
    }
}
