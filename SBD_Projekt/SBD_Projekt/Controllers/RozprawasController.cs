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

           

            var listaRozpraw = new List<RozprawaDetailsViewModel>();
            foreach (var rozprawa in _context.Rozprawa)
            {
                //  var rozprawa = await _context.Rozprawa.FirstOrDefaultAsync(m => m.id_sedzia == sedzia.id_sedzia);
                listaRozpraw.Add(new RozprawaDetailsViewModel
                {
                    id_rozprawa = rozprawa.id_rozprawa,
                    Godziny= _context.Godziny.FirstOrDefault(m => m.id_godziny == rozprawa.id_godziny),
                    Wydzial = _context.Wydzial.FirstOrDefault(m => m.id_wydzial == rozprawa.id_wydzial),
                    Sedzia = _context.Osoba.FirstOrDefault(m => m.id_osoba == _context.Sedzia.FirstOrDefault(m => m.id_sedzia == rozprawa.id_sedzia).id_osoba),
                    Prawnik = _context.Osoba.FirstOrDefault(m => m.id_osoba == _context.Prawnik.FirstOrDefault(m => m.id_prawnik == rozprawa.id_prawnik).id_osoba),
                    Klient = _context.Osoba.FirstOrDefault(m => m.id_osoba == _context.Klient.FirstOrDefault(m => m.id_klient == rozprawa.id_klient).id_osoba),
                    Dowody = _context.Dowod.Select(n => n).Where(n => n.id_rozprawy == rozprawa.id_rozprawa).ToList()
                });

            }

            return View(listaRozpraw);
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
            var rosprawaShow = new RozprawaDetailsViewModel
            {
                id_rozprawa = rozprawa.id_rozprawa,
                Godziny = _context.Godziny.FirstOrDefault(m => m.id_godziny == rozprawa.id_godziny),
                Wydzial = _context.Wydzial.FirstOrDefault(m => m.id_wydzial == rozprawa.id_wydzial),
                Sedzia = _context.Osoba.FirstOrDefault(m => m.id_osoba == _context.Sedzia.FirstOrDefault(m => m.id_sedzia == rozprawa.id_sedzia).id_osoba),
                Prawnik = _context.Osoba.FirstOrDefault(m => m.id_osoba == _context.Prawnik.FirstOrDefault(m => m.id_prawnik == rozprawa.id_prawnik).id_osoba),
                Klient = _context.Osoba.FirstOrDefault(m => m.id_osoba == _context.Klient.FirstOrDefault(m => m.id_klient == rozprawa.id_klient).id_osoba),
                Dowody= _context.Dowod.Select(n=>n).Where(n=>n.id_rozprawy== rozprawa.id_rozprawa).ToList()
            };


            if (rozprawa == null)
            {
                return NotFound();
            }

            return View(rosprawaShow);
        }

        // GET: Rozprawas/Create
        public IActionResult Create()
        {
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

            ViewData["WydzialsCount"] = _context.Wydzial.Count();
            ViewData["Wydzial"] = new SelectList(_context.Wydzial, "id_wydzial", "nazwa");


            ViewData["SedziasCount"] = _context.Sedzia.Count();
            var sedziaList = new List<Tuple<int, string>>();
            foreach (var osoba2 in _context.Osoba)
            {
                foreach (var sedzia in _context.Sedzia)
                {
                    if (osoba2.id_osoba == sedzia.id_osoba)
                        sedziaList.Add(new Tuple<int, string>(
                        sedzia.id_sedzia,
                        osoba2.Imie + " " + osoba2.Nazwisko)
                    );
                }
            }


            ViewData["Sedzia"] = new SelectList(sedziaList, "Item1", "Item2");

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
                        klient.id_klient,
                        osoba2.Imie + " " + osoba2.Nazwisko)
                    );
                }
            }
            ViewData["Klient"] = new SelectList(klientList, "Item1", "Item2");
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
            var GodzinyList = new List<Tuple<int, string>>();
            foreach (var godzina in _context.Godziny)
            {

                GodzinyList.Add(new Tuple<int, string>(
                godzina.id_godziny,
                godzina.OdGodziny + " DO " + godzina.DoGodziny)
            );

            }
            ViewData["Godziny"] = new SelectList(GodzinyList, "Item1", "Item2");

            ViewData["WydzialsCount"] = _context.Wydzial.Count();
            ViewData["Wydzial"] = new SelectList(_context.Wydzial, "id_wydzial", "nazwa");


            ViewData["SedziasCount"] = _context.Sedzia.Count();
            var sedziaList = new List<Tuple<int, string>>();
            foreach (var osoba2 in _context.Osoba)
            {
                foreach (var sedzia in _context.Sedzia)
                {
                    if (osoba2.id_osoba == sedzia.id_osoba)
                        sedziaList.Add(new Tuple<int, string>(
                        sedzia.id_sedzia,
                        osoba2.Imie + " " + osoba2.Nazwisko)
                    );
                }
            }


            ViewData["Sedzia"] = new SelectList(sedziaList, "Item1", "Item2");

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
            var rosprawaShow = new RozprawaDetailsViewModel
            {
                id_rozprawa = rozprawa.id_rozprawa,
                Wydzial = _context.Wydzial.FirstOrDefault(m => m.id_wydzial == rozprawa.id_wydzial),
                Sedzia = _context.Osoba.FirstOrDefault(m => m.id_osoba == _context.Sedzia.FirstOrDefault(m => m.id_sedzia == rozprawa.id_sedzia).id_osoba),
                Prawnik = _context.Osoba.FirstOrDefault(m => m.id_osoba == _context.Prawnik.FirstOrDefault(m => m.id_prawnik == rozprawa.id_prawnik).id_osoba),
                Klient = _context.Osoba.FirstOrDefault(m => m.id_osoba == _context.Klient.FirstOrDefault(m => m.id_klient == rozprawa.id_klient).id_osoba),
                Dowody = _context.Dowod.Select(n => n).Where(n => n.id_rozprawy == rozprawa.id_rozprawa).ToList()
            };
            if (rozprawa == null)
            {
                return NotFound();
            }

            return View(rosprawaShow);
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
