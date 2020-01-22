using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SBD_Projekt.Models;
using SBD_Projekt.Models.ViewModel;

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
            var ListaSędziów = new List<SedziaDetailsViewModel>();
            foreach (var sedzia in _context.Sedzia)
            {
                var sedz = await _context.Sedzia.FirstOrDefaultAsync(m => m.id_sedzia == sedzia.id_sedzia);
                ListaSędziów.Add(new SedziaDetailsViewModel
                {
                    id_sedzia = sedzia.id_wydzial,
                    Osoba = _context.Osoba.FirstOrDefault(m => m.id_osoba == sedzia.id_osoba),
                    Wydzial = _context.Wydzial.FirstOrDefault(m => m.id_wydzial == sedzia.id_wydzial),
                    Zarobki = _context.Zarobki.FirstOrDefault(m => m.id_zarobki == sedzia.id_zarobki)
                });

            }

            return View(ListaSędziów);
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



            var sedziaShow = new SedziaDetailsViewModel
            {
                id_sedzia = sedzia.id_wydzial,
                Osoba = _context.Osoba.FirstOrDefault(m => m.id_osoba == sedzia.id_osoba),
                Wydzial= _context.Wydzial.FirstOrDefault(m => m.id_wydzial== sedzia.id_wydzial),
                Zarobki = _context.Zarobki.FirstOrDefault(m => m.id_zarobki == sedzia.id_zarobki)
            };


            if (sedzia == null)
            {
                return NotFound();
            }

            return View(sedziaShow);
        }

        // GET: Sedzias/Create
        public IActionResult Create()
        {
            ViewData["OsobasCount"] = _context.Osoba.Count();


            var lista = new List<Tuple<int, string>>();
            foreach (var osoba in _context.Osoba)
            {
                lista.Add(new Tuple<int, string>(
                    osoba.id_osoba,
                    osoba.Imie + " " + osoba.Nazwisko)
                );
            }
            ViewData["Osoba"] = new SelectList(lista, "Item1", "Item2");
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



            var sedziaShow = new SedziaDetailsViewModel
            {
                id_sedzia = sedzia.id_wydzial,
                Osoba = _context.Osoba.FirstOrDefault(m => m.id_osoba == sedzia.id_osoba),
                Wydzial = _context.Wydzial.FirstOrDefault(m => m.id_wydzial == sedzia.id_wydzial),
                Zarobki = _context.Zarobki.FirstOrDefault(m => m.id_zarobki == sedzia.id_zarobki)
            };
            if (sedzia == null)
            {
                return NotFound();
            }

            return View(sedziaShow);
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
