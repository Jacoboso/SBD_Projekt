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
    public class GodziniesController : Controller
    {
        private readonly SBD_ProjektContext _context;

        public GodziniesController(SBD_ProjektContext context)
        {
            _context = context;
        }

        // GET: Godzinies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Godziny.ToListAsync());
        }

        // GET: Godzinies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var godziny = await _context.Godziny
                .FirstOrDefaultAsync(m => m.id_godziny == id);
            if (godziny == null)
            {
                return NotFound();
            }

            return View(godziny);
        }

        // GET: Godzinies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Godzinies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_godziny,OdGodziny,DoGodziny")] Godziny godziny)
        {
            if (ModelState.IsValid)
            {
                _context.Add(godziny);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(godziny);
        }

        // GET: Godzinies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var godziny = await _context.Godziny.FindAsync(id);
            if (godziny == null)
            {
                return NotFound();
            }
            return View(godziny);
        }

        // POST: Godzinies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_godziny,OdGodziny,DoGodziny")] Godziny godziny)
        {
            if (id != godziny.id_godziny)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(godziny);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GodzinyExists(godziny.id_godziny))
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
            return View(godziny);
        }

        // GET: Godzinies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var godziny = await _context.Godziny
                .FirstOrDefaultAsync(m => m.id_godziny == id);
            if (godziny == null)
            {
                return NotFound();
            }

            return View(godziny);
        }

        // POST: Godzinies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var godziny = await _context.Godziny.FindAsync(id);
            _context.Godziny.Remove(godziny);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GodzinyExists(int id)
        {
            return _context.Godziny.Any(e => e.id_godziny == id);
        }
    }
}
