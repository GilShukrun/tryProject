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
    public class CommunityWorksController : Controller
    {
        private readonly tryProjectContext _context;

        public CommunityWorksController(tryProjectContext context)
        {
            _context = context;
        }

        // GET: CommunityWorks
        public async Task<IActionResult> Index()
        {
            return View(await _context.CommunityWorks.Include(c=>c.Association).ToListAsync());
        }

        // GET: CommunityWorks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var communityWorks = await _context.CommunityWorks.Include(c=>c.Association)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (communityWorks == null)
            {
                return NotFound();
            }

            return View(communityWorks);
        }

        // GET: CommunityWorks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CommunityWorks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Decscription")] CommunityWorks communityWorks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(communityWorks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(communityWorks);
        }

        // GET: CommunityWorks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var communityWorks = await _context.CommunityWorks.FindAsync(id);
            if (communityWorks == null)
            {
                return NotFound();
            }
            return View(communityWorks);
        }

        // POST: CommunityWorks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Decscription")] CommunityWorks communityWorks)
        {
            if (id != communityWorks.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(communityWorks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommunityWorksExists(communityWorks.Id))
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
           // ViewData["Association"] = new SelectList(_context.Set<Association>(), "Id", "Name");
            return View(communityWorks);
        }

        // GET: CommunityWorks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var communityWorks = await _context.CommunityWorks.Include(c=>c.Association)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (communityWorks == null)
            {
                return NotFound();
            }

            return View(communityWorks);
        }

        // POST: CommunityWorks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var communityWorks = await _context.CommunityWorks.FindAsync(id);
            _context.CommunityWorks.Remove(communityWorks);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommunityWorksExists(int id)
        {
            return _context.CommunityWorks.Any(e => e.Id == id);
        }
    }
}
