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
    public class SpotkaniesController : Controller
    {
        private readonly SBD_ProjektContext _context;

        public SpotkaniesController(SBD_ProjektContext context)
        {
            _context = context;
        }

        // GET: Spotkanies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Spotkanie.ToListAsync());
        }

        // GET: Spotkanies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spotkanie = await _context.Spotkanie
                .FirstOrDefaultAsync(m => m.id_spotkanie == id);

            var SpotkanieShow = new SpotkanieDetailsViewModel
            {
                id_spotkanie=spotkanie.id_spotkanie,
                Sala= _context.Sala.FirstOrDefault(m => m.id_sala == spotkanie.id_sali),
                Godziny= _context.Godziny.FirstOrDefault(m => m.id_godziny == spotkanie.id_godziny),
                Prawnik = _context.Osoba.FirstOrDefault(m => m.id_osoba == _context.Prawnik.FirstOrDefault(m => m.id_prawnik == spotkanie.id_prawnik).id_osoba),
                Klient = _context.Osoba.FirstOrDefault(m => m.id_osoba == _context.Osoba.FirstOrDefault(m => m.id_osoba == spotkanie.id_klient).id_osoba)
            };


            if (spotkanie == null)
            {
                return NotFound();
            }

            return View(SpotkanieShow);
        }

        // GET: Spotkanies/Create
        public IActionResult Create()
        {


            ViewData["SalasCount"] = _context.Sala.Count();
            var sale = new List<Tuple<int, string>>();
            foreach (var sala in _context.Sala)
            {
                sale.Add(new Tuple<int, string>(
                    sala.id_sala,
                    sala.Rodzaj + " " + sala.Wielkosc)
                );
            }
            ViewData["Sala"] = new SelectList(sale, "Item1", "Item2");
      
            ViewData["GodziniesCount"] = _context.Godziny.Count();
            var GodzinyList = new List<Tuple<int, string>>();
            foreach (var godzina in _context.Godziny)
            {
                
                        GodzinyList.Add(new Tuple<int, string>(
                        godzina.id_godziny,
                        godzina.OdGodziny + " DO " + godzina.DoGodziny)
                    );
                
            }
            ViewData["Godziny"] = new SelectList(GodzinyList, "Item1", "Item2");
            ViewData["PrawniksCount"] = _context.Prawnik.Count();
            var prawnicyLista = new List<Tuple<int, string>>();
            foreach (var osoba2 in _context.Osoba)
            {
                foreach (var prawnik in _context.Prawnik)
                {
                    if (osoba2.id_osoba == prawnik.id_osoba)
                        prawnicyLista.Add(new Tuple<int, string>(
                        prawnik.id_prawnik,
                        osoba2.Imie + " " + osoba2.Nazwisko)
                    );
                }
            }
            ViewData["Prawnik"] = new SelectList(prawnicyLista, "Item1", "Item2");
            ViewData["KlientsCount"] = _context.Klient.Count();
            var klientList = new List<Tuple<int, string>>();
            foreach (var osoba2 in _context.Osoba)
            {
                foreach (var klient in _context.Klient)
                {
                    if (osoba2.id_osoba == klient.id_osoba)
                        klientList.Add(new Tuple<int, string>(
                        klient.id_osoba,
                        osoba2.Imie + " " + osoba2.Nazwisko)
                    );
                }
            }
            ViewData["Klient"] = new SelectList(klientList, "Item1", "Item2");    
            return View();
        }

        // POST: Spotkanies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_spotkanie,id_sali,id_godziny,id_prawnik,id_klient")] Spotkanie spotkanie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spotkanie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(spotkanie);
        }

        // GET: Spotkanies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spotkanie = await _context.Spotkanie.FindAsync(id);
            if (spotkanie == null)
            {
                return NotFound();
            }


            ViewData["SalasCount"] = _context.Sala.Count();

            var sale = new List<Tuple<int, string>>();
            foreach (var sala in _context.Sala)
            {
                sale.Add(new Tuple<int, string>(
                    sala.id_sala,
                    sala.Rodzaj + " " + sala.Wielkosc)
                );
            }
            ViewData["Sala"] = new SelectList(sale, "Item1", "Item2");

            ViewData["GodziniesCount"] = _context.Godziny.Count();
            var GodzinyList = new List<Tuple<int, string>>();
            foreach (var godzina in _context.Godziny)
            {

                GodzinyList.Add(new Tuple<int, string>(
                godzina.id_godziny,
                godzina.OdGodziny + " DO " + godzina.DoGodziny)
            );

            }
            ViewData["Godziny"] = new SelectList(GodzinyList, "Item1", "Item2");
            ViewData["PrawniksCount"] = _context.Prawnik.Count();
            var prawnicyLista = new List<Tuple<int, string>>();
            foreach (var osoba2 in _context.Osoba)
            {
                foreach (var prawnik in _context.Prawnik)
                {
                    if (osoba2.id_osoba == prawnik.id_osoba)
                        prawnicyLista.Add(new Tuple<int, string>(
                        prawnik.id_prawnik,
                        osoba2.Imie + " " + osoba2.Nazwisko)
                    );
                }
            }
            ViewData["Prawnik"] = new SelectList(prawnicyLista, "Item1", "Item2");
            ViewData["KlientsCount"] = _context.Klient.Count();
            var klientList = new List<Tuple<int, string>>();
            foreach (var osoba2 in _context.Osoba)
            {
                foreach (var klient in _context.Klient)
                {
                    if (osoba2.id_osoba == klient.id_osoba)
                        klientList.Add(new Tuple<int, string>(
                        klient.id_osoba,
                        osoba2.Imie + " " + osoba2.Nazwisko)
                    );
                }
            }
            ViewData["Klient"] = new SelectList(klientList, "Item1", "Item2");
            return View(spotkanie);
        }

        // POST: Spotkanies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_spotkanie,id_sali,id_godziny,id_prawnik,id_klient")] Spotkanie spotkanie)
        {
            if (id != spotkanie.id_spotkanie)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spotkanie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpotkanieExists(spotkanie.id_spotkanie))
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
            return View(spotkanie);
        }

        // GET: Spotkanies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spotkanie = await _context.Spotkanie
                 .FirstOrDefaultAsync(m => m.id_spotkanie == id);

            var SpotkanieShow = new SpotkanieDetailsViewModel
            {
                id_spotkanie = spotkanie.id_spotkanie,
                Sala = _context.Sala.FirstOrDefault(m => m.id_sala == spotkanie.id_sali),
                Godziny = _context.Godziny.FirstOrDefault(m => m.id_godziny == spotkanie.id_godziny),
                Prawnik = _context.Osoba.FirstOrDefault(m => m.id_osoba == _context.Prawnik.FirstOrDefault(m => m.id_prawnik == spotkanie.id_prawnik).id_osoba),
                Klient = _context.Osoba.FirstOrDefault(m => m.id_osoba == _context.Osoba.FirstOrDefault(m => m.id_osoba == spotkanie.id_klient).id_osoba)
            };
            if (spotkanie == null)
            {
                return NotFound();
            }

            return View(SpotkanieShow);
        }

        // POST: Spotkanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var spotkanie = await _context.Spotkanie.FindAsync(id);
            _context.Spotkanie.Remove(spotkanie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpotkanieExists(int id)
        {
            return _context.Spotkanie.Any(e => e.id_spotkanie == id);
        }
    }
}
