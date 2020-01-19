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
    public class RozprawasController : Controller
    {
        private readonly SBD_ProjektContext _context;

        public RozprawasController(SBD_ProjektContext context)
        {
            _context = context;
        }

        // GET: Rozprawas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rozprawa.ToListAsync());
        }

        // GET: Rozprawas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rozprawa = await _context.Rozprawa
                .FirstOrDefaultAsync(m => m.id_rozprawa == id);
            if (rozprawa == null)
            {
                return NotFound();
            }

            return View(rozprawa);
        }

        // GET: Rozprawas/Create
        public IActionResult Create()
        {
            ViewData["GodziniesCount"] = _context.Godziny.Count();
            ViewData["Godziny"] = new SelectList(_context.Godziny, "id_godziny", "id_godziny");
            ViewData["WydzialsCount"] = _context.Wydzial.Count();
            ViewData["Wydzial"] = new SelectList(_context.Wydzial, "id_wydzial", "id_wydzial");
            ViewData["DowodsCount"] = _context.Dowod.Count();
            ViewData["Dowod"] = new SelectList(_context.Dowod, "id_dowod", "Nazwa");
            ViewData["SedziasCount"] = _context.Sedzia.Count();
            ViewData["Sedzia"] = new SelectList(_context.Sedzia, "id_sedzia", "id_sedzia");
            ViewData["PrawniksCount"] = _context.Prawnik.Count();
            ViewData["Prawnik"] = new SelectList(_context.Prawnik, "id_prawnik", "id_prawnik");
            ViewData["KlientsCount"] = _context.Klient.Count();
            ViewData["Klient"] = new SelectList(_context.Klient, "id_klient", "id_klient");
            return View();
        }

        // POST: Rozprawas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_rozprawa,id_godziny,id_wydzial,id_dowod,id_sedzia,id_prawnik,id_klient")] Rozprawa rozprawa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rozprawa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rozprawa);
        }

        // GET: Rozprawas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rozprawa = await _context.Rozprawa.FindAsync(id);
            if (rozprawa == null)
            {
                return NotFound();
            }
            ViewData["GodziniesCount"] = _context.Godziny.Count();
            ViewData["Godziny"] = new SelectList(_context.Godziny, "id_godziny", "id_godziny");
            ViewData["WydzialsCount"] = _context.Wydzial.Count();
            ViewData["Wydzial"] = new SelectList(_context.Wydzial, "id_wydzial", "id_wydzial");
            ViewData["DowodsCount"] = _context.Dowod.Count();
            ViewData["Dowod"] = new SelectList(_context.Dowod, "id_dowod", "Nazwa");
            ViewData["SedziasCount"] = _context.Sedzia.Count();
            ViewData["Sedzia"] = new SelectList(_context.Sedzia, "id_sedzia", "id_sedzia");
            ViewData["PrawniksCount"] = _context.Prawnik.Count();
            ViewData["Prawnik"] = new SelectList(_context.Prawnik, "id_prawnik", "id_prawnik");
            ViewData["KlientsCount"] = _context.Klient.Count();
            ViewData["Klient"] = new SelectList(_context.Klient, "id_klient", "id_klient");
            return View(rozprawa);
        }

        // POST: Rozprawas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_rozprawa,id_godziny,id_wydzial,id_dowod,id_sedzia,id_prawnik,id_klient")] Rozprawa rozprawa)
        {
            if (id != rozprawa.id_rozprawa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rozprawa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RozprawaExists(rozprawa.id_rozprawa))
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
            return View(rozprawa);
        }

        // GET: Rozprawas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rozprawa = await _context.Rozprawa
                .FirstOrDefaultAsync(m => m.id_rozprawa == id);
            if (rozprawa == null)
            {
                return NotFound();
            }

            return View(rozprawa);
        }

        // POST: Rozprawas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rozprawa = await _context.Rozprawa.FindAsync(id);
            _context.Rozprawa.Remove(rozprawa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RozprawaExists(int id)
        {
            return _context.Rozprawa.Any(e => e.id_rozprawa == id);
        }
    }
}
