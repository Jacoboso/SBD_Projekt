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
    public class SedziasController : Controller
    {
        private readonly SBD_ProjektContext _context;

        public SedziasController(SBD_ProjektContext context)
        {
            _context = context;
        }

        // GET: Sedzias
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sedzia.ToListAsync());
        }

        // GET: Sedzias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sedzia = await _context.Sedzia
                .FirstOrDefaultAsync(m => m.id_sedzia == id);
            if (sedzia == null)
            {
                return NotFound();
            }

            return View(sedzia);
        }

        // GET: Sedzias/Create
        public IActionResult Create()
        {
            ViewData["OsobasCount"] = _context.Osoba.Count();
            ViewData["Osoba"] = new SelectList(_context.Osoba, "id_osoba", "Imie");
            ViewData["WydzialsCount"] = _context.Wydzial.Count();
            ViewData["Wydzial"] = new SelectList(_context.Wydzial, "id_wydzial", "nazwa");
            ViewData["ZarobkisCount"] = _context.Zarobki.Count();
            ViewData["Zarobki"] = new SelectList(_context.Zarobki, "id_zarobki", "zarobek");
            return View();
        }

        // POST: Sedzias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_sedzia,id_osoba,id_wydzial,id_zarobki")] Sedzia sedzia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sedzia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sedzia);
        }

        // GET: Sedzias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sedzia = await _context.Sedzia.FindAsync(id);
            if (sedzia == null)
            {
                return NotFound();
            }
            ViewData["OsobasCount"] = _context.Osoba.Count();
            ViewData["Osoba"] = new SelectList(_context.Osoba, "id_osoba", "Imie");
            ViewData["WydzialsCount"] = _context.Wydzial.Count();
            ViewData["Wydzial"] = new SelectList(_context.Wydzial, "id_wydzial", "nazwa");
            ViewData["ZarobkisCount"] = _context.Zarobki.Count();
            ViewData["Zarobki"] = new SelectList(_context.Zarobki, "id_zarobki", "zarobek");
            return View(sedzia);
        }

        // POST: Sedzias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_sedzia,id_osoba,id_wydzial,id_zarobki")] Sedzia sedzia)
        {
            if (id != sedzia.id_sedzia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sedzia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SedziaExists(sedzia.id_sedzia))
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
            return View(sedzia);
        }

        // GET: Sedzias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sedzia = await _context.Sedzia
                .FirstOrDefaultAsync(m => m.id_sedzia == id);
            if (sedzia == null)
            {
                return NotFound();
            }

            return View(sedzia);
        }

        // POST: Sedzias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sedzia = await _context.Sedzia.FindAsync(id);
            _context.Sedzia.Remove(sedzia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SedziaExists(int id)
        {
            return _context.Sedzia.Any(e => e.id_sedzia == id);
        }
    }
}
