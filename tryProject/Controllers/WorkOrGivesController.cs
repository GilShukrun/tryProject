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
    public class WorkOrGivesController : Controller
    {
        private readonly tryProjectContext _context;

        public WorkOrGivesController(tryProjectContext context)
        {
            _context = context;
        }

        // GET: WorkOrGives
        public async Task<IActionResult> Index()
        {
            return View(await _context.WorkOrGive.ToListAsync());
        }

        // GET: WorkOrGives/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOrGive = await _context.WorkOrGive
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workOrGive == null)
            {
                return NotFound();
            }

            return View(workOrGive);
        }

        // GET: WorkOrGives/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkOrGives/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] WorkOrGive workOrGive)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workOrGive);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workOrGive);
        }

        // GET: WorkOrGives/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOrGive = await _context.WorkOrGive.FindAsync(id);
            if (workOrGive == null)
            {
                return NotFound();
            }
            return View(workOrGive);
        }

        // POST: WorkOrGives/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] WorkOrGive workOrGive)
        {
            if (id != workOrGive.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workOrGive);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkOrGiveExists(workOrGive.Id))
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
            return View(workOrGive);
        }

        // GET: WorkOrGives/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOrGive = await _context.WorkOrGive
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workOrGive == null)
            {
                return NotFound();
            }

            return View(workOrGive);
        }

        // POST: WorkOrGives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workOrGive = await _context.WorkOrGive.FindAsync(id);
            _context.WorkOrGive.Remove(workOrGive);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkOrGiveExists(int id)
        {
            return _context.WorkOrGive.Any(e => e.Id == id);
        }
    }
}
