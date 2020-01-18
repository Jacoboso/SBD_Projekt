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
    public class ZarobkisController : Controller
    {
        private readonly SBD_ProjektContext _context;

        public ZarobkisController(SBD_ProjektContext context)
        {
            _context = context;
        }

        // GET: Zarobkis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zarobki.ToListAsync());
        }

        // GET: Zarobkis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zarobki = await _context.Zarobki
                .FirstOrDefaultAsync(m => m.id_zarobki == id);
            if (zarobki == null)
            {
                return NotFound();
            }

            return View(zarobki);
        }

        // GET: Zarobkis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zarobkis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_zarobki,zarobek,premia")] Zarobki zarobki)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zarobki);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zarobki);
        }

        // GET: Zarobkis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zarobki = await _context.Zarobki.FindAsync(id);
            if (zarobki == null)
            {
                return NotFound();
            }
            return View(zarobki);
        }

        // POST: Zarobkis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_zarobki,zarobek,premia")] Zarobki zarobki)
        {
            if (id != zarobki.id_zarobki)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zarobki);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZarobkiExists(zarobki.id_zarobki))
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
            return View(zarobki);
        }

        // GET: Zarobkis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zarobki = await _context.Zarobki
                .FirstOrDefaultAsync(m => m.id_zarobki == id);
            if (zarobki == null)
            {
                return NotFound();
            }

            return View(zarobki);
        }

        // POST: Zarobkis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zarobki = await _context.Zarobki.FindAsync(id);
            _context.Zarobki.Remove(zarobki);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZarobkiExists(int id)
        {
            return _context.Zarobki.Any(e => e.id_zarobki == id);
        }
    }
}
