using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tryProject.Data;
using tryProject.Models;

namespace tryProject.Controllers
{
    public class CatersToController : Controller
    {
        private readonly tryProjectContext _context;

        public CatersToController(tryProjectContext context)
        {
            _context = context;
        }

        // GET: CatersTo
        public async Task<IActionResult> Index()
        {
            return View(await _context.CatersTo.ToListAsync());
        }

        // GET: CatersTo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catersTo = await _context.CatersTo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catersTo == null)
            {
                return NotFound();
            }

            return View(catersTo);
        }

        // GET: CatersTo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatersTo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] CatersTo catersTo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catersTo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catersTo);
        }

        // GET: CatersTo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catersTo = await _context.CatersTo.FindAsync(id);
            if (catersTo == null)
            {
                return NotFound();
            }
            return View(catersTo);
        }

        // POST: CatersTo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] CatersTo catersTo)
        {
            if (id != catersTo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catersTo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatersToExists(catersTo.Id))
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
            return View(catersTo);
        }

        // GET: CatersTo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catersTo = await _context.CatersTo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catersTo == null)
            {
                return NotFound();
            }

            return View(catersTo);
        }

        // POST: CatersTo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catersTo = await _context.CatersTo.FindAsync(id);
            _context.CatersTo.Remove(catersTo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatersToExists(int id)
        {
            return _context.CatersTo.Any(e => e.Id == id);
        }
    }
}
