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
    public class BudyneksController : Controller
    {
        private readonly SBD_ProjektContext _context;

        public BudyneksController(SBD_ProjektContext context)
        {
            _context = context;
        }

        // GET: Budyneks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Budynek.ToListAsync());
        }

        // GET: Budyneks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var budynek = await _context.Budynek
                .FirstOrDefaultAsync(m => m.id_budynek == id);
            if (budynek == null)
            {
                return NotFound();
            }

            return View(budynek);
        }

        // GET: Budyneks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Budyneks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_budynek,Miasto,Ulica,KodPocztowy,NrBudynku")] Budynek budynek)
        {
            if (ModelState.IsValid)
            {
                _context.Add(budynek);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(budynek);
        }

        // GET: Budyneks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var budynek = await _context.Budynek.FindAsync(id);
            if (budynek == null)
            {
                return NotFound();
            }
            return View(budynek);
        }

        // POST: Budyneks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_budynek,Miasto,Ulica,KodPocztowy,NrBudynku")] Budynek budynek)
        {
            if (id != budynek.id_budynek)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(budynek);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BudynekExists(budynek.id_budynek))
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
            return View(budynek);
        }

        // GET: Budyneks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var budynek = await _context.Budynek
                .FirstOrDefaultAsync(m => m.id_budynek == id);
            if (budynek == null)
            {
                return NotFound();
            }

            return View(budynek);
        }

        // POST: Budyneks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var budynek = await _context.Budynek.FindAsync(id);
            _context.Budynek.Remove(budynek);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BudynekExists(int id)
        {
            return _context.Budynek.Any(e => e.id_budynek == id);
        }
    }
}
