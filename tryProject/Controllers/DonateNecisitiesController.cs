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
    public class DonateNecisitiesController : Controller
    {
        private readonly tryProjectContext _context;

        public DonateNecisitiesController(tryProjectContext context)
        {
            _context = context;
        }

        // GET: DonateNecisities
        public async Task<IActionResult> Index()
        {
            return View(await _context.DonateNecisities.ToListAsync());
        }

        // GET: DonateNecisities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donateNecisities = await _context.DonateNecisities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (donateNecisities == null)
            {
                return NotFound();
            }

            return View(donateNecisities);
        }

        // GET: DonateNecisities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DonateNecisities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,area,whoIsFor")] DonateNecisities donateNecisities)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donateNecisities);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(donateNecisities);
        }

        // GET: DonateNecisities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donateNecisities = await _context.DonateNecisities.FindAsync(id);
            if (donateNecisities == null)
            {
                return NotFound();
            }
            return View(donateNecisities);
        }

        // POST: DonateNecisities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,area,whoIsFor")] DonateNecisities donateNecisities)
        {
            if (id != donateNecisities.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donateNecisities);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonateNecisitiesExists(donateNecisities.Id))
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
            return View(donateNecisities);
        }

        // GET: DonateNecisities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donateNecisities = await _context.DonateNecisities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (donateNecisities == null)
            {
                return NotFound();
            }

            return View(donateNecisities);
        }

        // POST: DonateNecisities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var donateNecisities = await _context.DonateNecisities.FindAsync(id);
            _context.DonateNecisities.Remove(donateNecisities);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonateNecisitiesExists(int id)
        {
            return _context.DonateNecisities.Any(e => e.Id == id);
        }
    }
}
