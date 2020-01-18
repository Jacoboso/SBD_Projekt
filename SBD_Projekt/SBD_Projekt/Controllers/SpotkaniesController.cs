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
            if (spotkanie == null)
            {
                return NotFound();
            }

            return View(spotkanie);
        }

        // GET: Spotkanies/Create
        public IActionResult Create()
        {
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
            if (spotkanie == null)
            {
                return NotFound();
            }

            return View(spotkanie);
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
