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
    public class ObslugasController : Controller
    {
        private readonly SBD_ProjektContext _context;

        public ObslugasController(SBD_ProjektContext context)
        {
            _context = context;
        }

        // GET: Obslugas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Obsluga.ToListAsync());
        }

        // GET: Obslugas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obsluga = await _context.Obsluga
                .FirstOrDefaultAsync(m => m.id_obsluga == id);
            if (obsluga == null)
            {
                return NotFound();
            }

            return View(obsluga);
        }

        // GET: Obslugas/Create
        public IActionResult Create()
        {
            ViewData["OsobasCount"] = _context.Osoba.Count();
            ViewData["Osoba"] = new SelectList(_context.Osoba, "id_osoba", "Imie");
            ViewData["ZarobkisCount"] = _context.Zarobki.Count();
            ViewData["Zarobki"] = new SelectList(_context.Zarobki, "id_zarobki", "zarobek");
            ViewData["GodziniesCount"] = _context.Godziny.Count();
            ViewData["Godziny"] = new SelectList(_context.Godziny, "id_godziny", "OdGodziny");
            return View();
        }

        // POST: Obslugas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_obsluga,id_osoba,id_zarobki,id_godziny,typ")] Obsluga obsluga)
        {
            if (ModelState.IsValid)
            {
                _context.Add(obsluga);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(obsluga);
        }

        // GET: Obslugas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obsluga = await _context.Obsluga.FindAsync(id);
            if (obsluga == null)
            {
                return NotFound();
            }
            ViewData["OsobasCount"] = _context.Osoba.Count();
            ViewData["Osoba"] = new SelectList(_context.Osoba, "id_osoba", "Imie");
            ViewData["ZarobkisCount"] = _context.Zarobki.Count();
            ViewData["Zarobki"] = new SelectList(_context.Zarobki, "id_zarobki", "zarobek");
            ViewData["GodziniesCount"] = _context.Godziny.Count();
            ViewData["Godziny"] = new SelectList(_context.Godziny, "id_godziny", "OdGodziny");
            return View(obsluga);
        }

        // POST: Obslugas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_obsluga,id_osoba,id_zarobki,id_godziny,typ")] Obsluga obsluga)
        {
            if (id != obsluga.id_obsluga)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(obsluga);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObslugaExists(obsluga.id_obsluga))
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
            return View(obsluga);
        }

        // GET: Obslugas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obsluga = await _context.Obsluga
                .FirstOrDefaultAsync(m => m.id_obsluga == id);
            if (obsluga == null)
            {
                return NotFound();
            }

            return View(obsluga);
        }

        // POST: Obslugas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var obsluga = await _context.Obsluga.FindAsync(id);
            _context.Obsluga.Remove(obsluga);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObslugaExists(int id)
        {
            return _context.Obsluga.Any(e => e.id_obsluga == id);
        }
    }
}
