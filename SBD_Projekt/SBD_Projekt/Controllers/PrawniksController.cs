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
            var ListaPrawników = new List<PrawnikDetailsViewModel>();
            foreach(var prawnik in _context.Prawnik)
            {
                var osoba = await _context.Osoba.FirstOrDefaultAsync(n => n.id_osoba == prawnik.id_osoba);
                ListaPrawników.Add(new PrawnikDetailsViewModel
                {
                    id_prawnik = prawnik.id_prawnik,
                    Osoba = osoba,
                    Adres = await _context.Adres.FirstOrDefaultAsync(n => n.id_adres == osoba.id_adres),
                    Godziny = await _context.Godziny.FirstOrDefaultAsync(n => n.id_godziny == prawnik.id_godziny),
                    Zarobki = await _context.Zarobki.FirstOrDefaultAsync(n => n.id_zarobki == prawnik.id_zarobki),
                    Specjalizacje = await _context.Specjalizacja.FirstOrDefaultAsync(n => n.id_specjalizacja == prawnik.id_specjalizacja)
                }) ;

            }

            return View(ListaPrawników);
        }

        // GET: Prawniks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var prawnik = await _context.Prawnik.FirstOrDefaultAsync(m => m.id_prawnik == id);
            var osoba = await _context.Osoba.FirstOrDefaultAsync(n => n.id_osoba == prawnik.id_osoba);
            var prawnikToShow = new PrawnikDetailsViewModel
            {
                id_prawnik=prawnik.id_prawnik,
                Osoba = osoba,
                Adres = await _context.Adres.FirstOrDefaultAsync(n => n.id_adres == osoba.id_adres),
                Godziny = await _context.Godziny.FirstOrDefaultAsync(n => n.id_godziny == prawnik.id_godziny),
                Zarobki = await _context.Zarobki.FirstOrDefaultAsync(n => n.id_zarobki == prawnik.id_zarobki),
                Specjalizacje = await _context.Specjalizacja.FirstOrDefaultAsync(n => n.id_specjalizacja == prawnik.id_specjalizacja)
            };

           
            if (prawnik == null)
            {
                return NotFound();
            }

            return View(prawnikToShow);
        }

        // GET: Prawniks/Create
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

            var lista = new List<Tuple<int, string>>();
            foreach (var osoba in _context.Osoba)
            {
                lista.Add(new Tuple<int, string>(
                    osoba.id_adres,
                    osoba.Imie + " " + osoba.Nazwisko)
                );
            }
            ViewData["Osoba"] = new SelectList(lista, "Item1", "Item2");
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

           
            var prawnik = await _context.Prawnik.FirstOrDefaultAsync(m => m.id_prawnik == id);
            var osoba = await _context.Osoba.FirstOrDefaultAsync(n => n.id_osoba == prawnik.id_osoba);
            var prawnikToShow = new PrawnikDetailsViewModel
            {
                id_prawnik = prawnik.id_prawnik,
                Osoba = osoba,
                Adres = await _context.Adres.FirstOrDefaultAsync(n => n.id_adres == osoba.id_adres),
                Godziny = await _context.Godziny.FirstOrDefaultAsync(n => n.id_godziny == prawnik.id_godziny),
                Zarobki = await _context.Zarobki.FirstOrDefaultAsync(n => n.id_zarobki == prawnik.id_zarobki),
                Specjalizacje = await _context.Specjalizacja.FirstOrDefaultAsync(n => n.id_specjalizacja == prawnik.id_specjalizacja)
            };

            if (prawnik == null)
            {
                return NotFound();
            }

            return View(prawnikToShow);
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
