﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SBD_Projekt.Models;

namespace SBD_Projekt.Controllers
{
    public class WydzialsController : Controller
    {
        private readonly SBD_ProjektContext _context;

        public WydzialsController(SBD_ProjektContext context)
        {
            _context = context;
        }

        // GET: Wydzials
        public async Task<IActionResult> Index()
        {
            return View(await _context.Wydzial.ToListAsync());
        }

        // GET: Wydzials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wydzial = await _context.Wydzial
                .FirstOrDefaultAsync(m => m.id_wydzial == id);
            if (wydzial == null)
            {
                return NotFound();
            }

            return View(wydzial);
        }

        // GET: Wydzials/Create
        public IActionResult Create()
        {
            ViewData["BudyneksCount"] = _context.Budynek.Count();
            ViewData["Budynek"] = new SelectList(_context.Budynek, "id_budynek", "Miasto");
            return View();
        }

        // POST: Wydzials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_wydzial,id_budynku,nazwa")] Wydzial wydzial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wydzial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wydzial);
        }

        // GET: Wydzials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wydzial = await _context.Wydzial.FindAsync(id);
            if (wydzial == null)
            {
                return NotFound();
            }

            ViewData["BudyneksCount"] = _context.Budynek.Count();
            ViewData["Budynek"] = new SelectList(_context.Budynek, "id_budynek", "Miasto");
            return View(wydzial);
        }

        // POST: Wydzials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_wydzial,id_budynku,nazwa")] Wydzial wydzial)
        {
            if (id != wydzial.id_wydzial)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wydzial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WydzialExists(wydzial.id_wydzial))
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
            return View(wydzial);
        }

        // GET: Wydzials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wydzial = await _context.Wydzial
                .FirstOrDefaultAsync(m => m.id_wydzial == id);
            if (wydzial == null)
            {
                return NotFound();
            }

            return View(wydzial);
        }

        // POST: Wydzials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wydzial = await _context.Wydzial.FindAsync(id);
            _context.Wydzial.Remove(wydzial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WydzialExists(int id)
        {
            return _context.Wydzial.Any(e => e.id_wydzial == id);
        }
    }
}