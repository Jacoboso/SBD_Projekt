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
    public class PrawniksController : Controller
    {
        private readonly SBD_ProjektContext _context;

        public PrawniksController(SBD_ProjektContext context)
        {
            _context = context;
        }

        // GET: Prawniks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Prawnik.ToListAsync());
        }

        // GET: Prawniks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prawnik = await _context.Prawnik
                .FirstOrDefaultAsync(m => m.id_prawnik == id);
            if (prawnik == null)
            {
                return NotFound();
            }

            return View(prawnik);
        }

        // GET: Prawniks/Create
        public IActionResult Create()
        {
            ViewData["OsobasCount"] = _context.Osoba.Count();
            ViewData["Osoba"] = new SelectList(_context.Osoba, "id_osoba", "Imie");
            ViewData["ZarobkisCount"] = _context.Zarobki.Count();
            ViewData["Zarobki"] = new SelectList(_context.Zarobki, "id_zarobki", "zarobek");
            ViewData["GodziniesCount"] = _context.Godziny.Count();
            ViewData["Godziny"] = new SelectList(_context.Godziny, "id_godziny", "OdGodziny");
            ViewData["SpecjalizacjasCount"] = _context.Specjalizacja.Count();
            ViewData["Specjalizacja"] = new SelectList(_context.Specjalizacja, "id_specjalizacja", "nazwa");
            return View();
        }

        // POST: Prawniks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_prawnik,id_osoba,id_godziny,id_zarobki,id_specjalizacja")] Prawnik prawnik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prawnik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prawnik);
        }

        // GET: Prawniks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prawnik = await _context.Prawnik.FindAsync(id);
            if (prawnik == null)
            {
                return NotFound();
            }
            ViewData["OsobasCount"] = _context.Osoba.Count();
            ViewData["Osoba"] = new SelectList(_context.Osoba, "id_osoba", "Imie");
            ViewData["ZarobkisCount"] = _context.Zarobki.Count();
            ViewData["Zarobki"] = new SelectList(_context.Zarobki, "id_zarobki", "zarobek");
            ViewData["GodziniesCount"] = _context.Godziny.Count();
            ViewData["Godziny"] = new SelectList(_context.Godziny, "id_godziny", "OdGodziny");
            ViewData["SpecjalizacjasCount"] = _context.Specjalizacja.Count();
            ViewData["Specjalizacja"] = new SelectList(_context.Specjalizacja, "id_specjalizacja", "nazwa");
            return View(prawnik);
        }

        // POST: Prawniks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_prawnik,id_osoba,id_godziny,id_zarobki,id_specjalizacja")] Prawnik prawnik)
        {
            if (id != prawnik.id_prawnik)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prawnik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrawnikExists(prawnik.id_prawnik))
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
            return View(prawnik);
        }

        // GET: Prawniks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prawnik = await _context.Prawnik
                .FirstOrDefaultAsync(m => m.id_prawnik == id);
            if (prawnik == null)
            {
                return NotFound();
            }

            return View(prawnik);
        }

        // POST: Prawniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prawnik = await _context.Prawnik.FindAsync(id);
            _context.Prawnik.Remove(prawnik);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrawnikExists(int id)
        {
            return _context.Prawnik.Any(e => e.id_prawnik == id);
        }
    }
}
