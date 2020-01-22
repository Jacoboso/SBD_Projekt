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
    public class OsobasController : Controller
    {
        private readonly SBD_ProjektContext _context;

        public OsobasController(SBD_ProjektContext context)
        {
            _context = context;
        }

        // GET: Osobas
        public async Task<IActionResult> Index()
        {
            var ListaOsób = new List<OsobaDetailsViewModel>();
            foreach (var osoba in _context.Osoba)
            {
                var os = await _context.Osoba.FirstOrDefaultAsync(m => m.id_osoba == osoba.id_osoba);
                ListaOsób.Add(new OsobaDetailsViewModel
                {
                    Osoba = osoba,
                    Adres = await _context.Adres.FirstOrDefaultAsync(m => m.id_adres == osoba.id_adres)

                });
               
            }

            return View(ListaOsób);
        }

        // GET: Osobas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var osoba = await _context.Osoba
                .FirstOrDefaultAsync(m => m.id_osoba == id);

            var viewModel = new OsobaDetailsViewModel
            {
                Osoba = osoba,
                Adres = await _context.Adres.FirstOrDefaultAsync(m => m.id_adres == osoba.id_adres)

            };

            if (osoba == null)
            {
                return NotFound();
            }

            


            return View(viewModel);
        }

        // GET: Osobas/Create
        public IActionResult Create()
        {
            ViewData["AdresCount"] = _context.Adres.Count();

            var lista = new List<Tuple<int, string>>();
            foreach(var adres in _context.Adres)
            {
                lista.Add(new Tuple<int, string>(
                    adres.id_adres, 
                    adres.id_adres + " " + adres.Kraj + " " + adres.Miasto + " " + adres.Ulica + " " + adres.Nr_domu + "/" + adres.Nr_miszkania)
                );
            }          
            ViewData["Adres"] = new SelectList(lista, "Item1", "Item2");
            return View();
        }

        // POST: Osobas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_osoba,Imie,Nazwisko,Pesel,id_adres,Telefon")] Osoba osoba)
        {
            
            if (ModelState.IsValid)
            {
                _context.Add(osoba);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(osoba);
        }

        // GET: Osobas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var osoba = await _context.Osoba.FindAsync(id);
            if (osoba == null)
            {
                return NotFound();
            }
            ViewData["AdresCount"] = _context.Adres.Count();
            ViewData["Adres"] = new SelectList(_context.Adres, "id_adres", "Miasto");
            return View(osoba);
        }

        // POST: Osobas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_osoba,Imie,Nazwisko,Pesel,id_adres,Telefon")] Osoba osoba)
        {
            if (id != osoba.id_osoba)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(osoba);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OsobaExists(osoba.id_osoba))
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
            return View(osoba);
        }

        // GET: Osobas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var osoba = await _context.Osoba
                .FirstOrDefaultAsync(m => m.id_osoba == id);
            if (osoba == null)
            {
                return NotFound();
            }

            return View(osoba);
        }

        // POST: Osobas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var osoba = await _context.Osoba.FindAsync(id);
            _context.Osoba.Remove(osoba);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OsobaExists(int id)
        {
            return _context.Osoba.Any(e => e.id_osoba == id);
        }
    }
}
