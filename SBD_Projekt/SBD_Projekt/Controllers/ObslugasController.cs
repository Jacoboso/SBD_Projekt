using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SBD_Projekt.Models.ViewModel;
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
            var obslugaList = new List<OblugaDetailsViewModel>();
            foreach(var obsluga in _context.Obsluga)
            {
                var osoba = await _context.Osoba.FirstOrDefaultAsync(n => n.id_osoba == obsluga.id_osoba);
                obslugaList.Add(new OblugaDetailsViewModel
                {
                    id_obsluga = obsluga.id_obsluga,
                    Osoba = osoba,
                    Adres = await _context.Adres.FirstOrDefaultAsync(n => n.id_adres == osoba.id_adres),
                    Godziny = await _context.Godziny.FirstOrDefaultAsync(n => n.id_godziny == obsluga.id_godziny),
                    Zarobki = await _context.Zarobki.FirstOrDefaultAsync(n => n.id_zarobki == obsluga.id_zarobki),
                    typ = obsluga.typ
                });
            }
            return View(obslugaList);
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
            var osoba = await _context.Osoba.FirstOrDefaultAsync(n => n.id_osoba == obsluga.id_osoba);
            var obslugaToShow = new OblugaDetailsViewModel
            {
                id_obsluga = obsluga.id_obsluga,
                Osoba = osoba,
                Adres = await _context.Adres.FirstOrDefaultAsync(n => n.id_adres == osoba.id_adres),
                Godziny = await _context.Godziny.FirstOrDefaultAsync(n => n.id_godziny == obsluga.id_godziny),
                Zarobki = await _context.Zarobki.FirstOrDefaultAsync(n => n.id_zarobki == obsluga.id_zarobki),
                typ= obsluga.typ      
            };


            if (obsluga == null)
            {
                return NotFound();
            }

            return View(obslugaToShow);
        }

        // GET: Obslugas/Create
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
            var GodzinyList = new List<Tuple<int, string>>();
            foreach (var godzina in _context.Godziny)
            {
                var odGodziny = godzina.OdGodziny.ToShortTimeString();
                var doGodziny = godzina.DoGodziny.ToShortTimeString();

                GodzinyList.Add(new Tuple<int, string>(
                    godzina.id_godziny,
                    odGodziny + " DO " + doGodziny)
                );

            }
            ViewData["Godziny"] = new SelectList(GodzinyList, "Item1", "Item2");
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
            var GodzinyList = new List<Tuple<int, string>>();
            foreach (var godzina in _context.Godziny)
            {
                var odGodziny = godzina.OdGodziny.ToShortTimeString();
                var doGodziny = godzina.DoGodziny.ToShortTimeString();

                GodzinyList.Add(new Tuple<int, string>(
                    godzina.id_godziny,
                    odGodziny + " DO " + doGodziny)
                );

            }
            ViewData["Godziny"] = new SelectList(GodzinyList, "Item1", "Item2");
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
            var osoba = await _context.Osoba.FirstOrDefaultAsync(n => n.id_osoba == obsluga.id_osoba);
            var obslugaToShow = new OblugaDetailsViewModel
            {
                id_obsluga = obsluga.id_obsluga,
                Osoba = osoba,
                Adres = await _context.Adres.FirstOrDefaultAsync(n => n.id_adres == osoba.id_adres),
                Godziny = await _context.Godziny.FirstOrDefaultAsync(n => n.id_godziny == obsluga.id_godziny),
                Zarobki = await _context.Zarobki.FirstOrDefaultAsync(n => n.id_zarobki == obsluga.id_zarobki),
                typ = obsluga.typ
            };


            if (obsluga == null)
            {
                return NotFound();
            }

            return View(obslugaToShow);
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
