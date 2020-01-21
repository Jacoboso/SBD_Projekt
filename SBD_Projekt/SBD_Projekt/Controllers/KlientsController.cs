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
    public class KlientsController : Controller
    {
        private readonly SBD_ProjektContext _context;

        public KlientsController(SBD_ProjektContext context)
        {
            _context = context;
        }

        // GET: Klients
        public async Task<IActionResult> Index()
        {
            return View(await _context.Klient.ToListAsync());
        }

        // GET: Klients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klient = await _context.Klient
                .FirstOrDefaultAsync(m => m.id_klient == id);

            var klientDet = new KlientDetailsViewModel
            {
                Klient = _context.Osoba.FirstOrDefault(m => m.id_osoba == klient.id_osoba),
                Prawnik = _context.Osoba.FirstOrDefault(m => m.id_osoba == klient.id_prawnik),
                Klient_Adres= _context.Adres.FirstOrDefault(m => m.id_adres == _context.Osoba.FirstOrDefault(m => m.id_osoba == klient.id_osoba).id_adres),
                Prawnik_Specjalizacja = _context.Specjalizacja.FirstOrDefault(m => m.id_specjalizacja == _context.Prawnik.FirstOrDefault(m => m.id_prawnik == klient.id_prawnik).id_specjalizacja),
            };


            if (klient == null)
            {
                return NotFound();
            }

            return View(klientDet);
        }

        // GET: Klients/Create
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

            ViewData["PrawniksCount"] = _context.Prawnik.Count();      
            var prawnicyLista = new List<Tuple<int, string>>();
            foreach (var osoba2 in _context.Osoba)
            {              
                foreach (var prawnik in _context.Prawnik)
                {
                    if(osoba2.id_osoba==prawnik.id_osoba)
                    prawnicyLista.Add(new Tuple<int, string>(
                    prawnik.id_prawnik,
                    osoba2.Imie + " " + osoba2.Nazwisko)
                );
                } 
            }
            ViewData["Prawnik"] = new SelectList(prawnicyLista, "Item1", "Item2");
            return View();
        }

        // POST: Klients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_klient,id_osoba,id_prawnik")] Klient klient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(klient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(klient);
        }

        // GET: Klients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klient = await _context.Klient.FindAsync(id);
            if (klient == null)
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
            return View(klient);
        }

        // POST: Klients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_klient,id_osoba,id_prawnik")] Klient klient)
        {
            if (id != klient.id_klient)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(klient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KlientExists(klient.id_klient))
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
            return View(klient);
        }

        // GET: Klients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

           

            var klient = await _context.Klient
    .FirstOrDefaultAsync(m => m.id_klient == id);

            var klientDet = new KlientDetailsViewModel
            {
                Klient = _context.Osoba.FirstOrDefault(m => m.id_osoba == klient.id_osoba),
                Prawnik = _context.Osoba.FirstOrDefault(m => m.id_osoba == klient.id_prawnik),
                Klient_Adres = _context.Adres.FirstOrDefault(m => m.id_adres == _context.Osoba.FirstOrDefault(m => m.id_osoba == klient.id_osoba).id_adres),
                Prawnik_Specjalizacja = _context.Specjalizacja.FirstOrDefault(m => m.id_specjalizacja == _context.Prawnik.FirstOrDefault(m => m.id_prawnik == klient.id_prawnik).id_specjalizacja),
            };
            if (klient == null)
            {
                return NotFound();
            }

            return View(klientDet);
        }

        // POST: Klients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var klient = await _context.Klient.FindAsync(id);
            _context.Klient.Remove(klient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KlientExists(int id)
        {
            return _context.Klient.Any(e => e.id_klient == id);
        }
    }
}
