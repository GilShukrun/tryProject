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
    public class MoneyDonationsController : Controller
    {
        private readonly tryProjectContext _context;

        public MoneyDonationsController(tryProjectContext context)
        {
            _context = context;
        }

        // GET: MoneyDonations
        public async Task<IActionResult> Index()
        {
           // var tryProjectContext = _context.MoneyDonation.Include(m => m.Purpose);
            return View(await _context.MoneyDonation.Include(m=>m.Purpose).ToListAsync());
        }

        // GET: MoneyDonations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moneyDonation = await _context.MoneyDonation.Include(m=>m.Purpose)
                .Include(m => m.Purpose)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moneyDonation == null)
            {
                return NotFound();
            }

            return View(moneyDonation);
        }

        // GET: MoneyDonations/Create
        public IActionResult Create()
        {
            ViewData["PurposeId"] = new SelectList(_context.Purpose, nameof(Purpose.Id),nameof(Purpose.Name));
            return View();
        }

        // POST: MoneyDonations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Sum,PurposeId")] MoneyDonation moneyDonation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(moneyDonation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PurposeId"] = new SelectList(_context.Purpose, nameof(Purpose.Id), nameof(Purpose.Name));
            return View(moneyDonation);
        }

        // GET: MoneyDonations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moneyDonation = await _context.MoneyDonation.FindAsync(id);
            if (moneyDonation == null)
            {
                return NotFound();
            }
            ViewData["Purpose"] = new SelectList(_context.Purpose, "Id", "Name", moneyDonation.Purpose);
            return View(moneyDonation);
        }

        // POST: MoneyDonations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Sum,PurposeName")] MoneyDonation moneyDonation)
        {
            if (id != moneyDonation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moneyDonation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoneyDonationExists(moneyDonation.Id))
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
            ViewData["Purpose"] = new SelectList(_context.Purpose, "Id", "Id", moneyDonation.Purpose);
            return View(moneyDonation);
        }

        // GET: MoneyDonations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moneyDonation = await _context.MoneyDonation
                .Include(m => m.Purpose)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moneyDonation == null)
            {
                return NotFound();
            }

            return View(moneyDonation);
        }

        // POST: MoneyDonations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var moneyDonation = await _context.MoneyDonation.FindAsync(id);
            _context.MoneyDonation.Remove(moneyDonation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MoneyDonationExists(int id)
        {
            return _context.MoneyDonation.Any(e => e.Id == id);
        }
    }
}
