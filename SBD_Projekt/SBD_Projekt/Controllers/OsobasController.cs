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
            return View(await _context.Osoba.ToListAsync());
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
