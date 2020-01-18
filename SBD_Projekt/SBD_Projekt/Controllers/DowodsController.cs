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
    public class DowodsController : Controller
    {
        private readonly SBD_ProjektContext _context;

        public DowodsController(SBD_ProjektContext context)
        {
            _context = context;
        }

        // GET: Dowods
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dowod.ToListAsync());
        }

        // GET: Dowods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dowod = await _context.Dowod
                .FirstOrDefaultAsync(m => m.id_dowod == id);
            if (dowod == null)
            {
                return NotFound();
            }

            return View(dowod);
        }

        // GET: Dowods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dowods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_dowod,Nazwa,Typ")] Dowod dowod)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dowod);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dowod);
        }

        // GET: Dowods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dowod = await _context.Dowod.FindAsync(id);
            if (dowod == null)
            {
                return NotFound();
            }
            return View(dowod);
        }

        // POST: Dowods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_dowod,Nazwa,Typ")] Dowod dowod)
        {
            if (id != dowod.id_dowod)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dowod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DowodExists(dowod.id_dowod))
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
            return View(dowod);
        }

        // GET: Dowods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dowod = await _context.Dowod
                .FirstOrDefaultAsync(m => m.id_dowod == id);
            if (dowod == null)
            {
                return NotFound();
            }

            return View(dowod);
        }

        // POST: Dowods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dowod = await _context.Dowod.FindAsync(id);
            _context.Dowod.Remove(dowod);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DowodExists(int id)
        {
            return _context.Dowod.Any(e => e.id_dowod == id);
        }
    }
}
