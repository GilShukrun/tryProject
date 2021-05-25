using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using tryProject.Data;
using tryProject.Models;

namespace tryProject.Controllers
{
    public class AssociationsController : Controller
    {
        private readonly tryProjectContext _context;
        private object ap;

        public AssociationsController(tryProjectContext context)
        {
            _context = context;
        }

        // GET: Associations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Association.Include(p => p.Purposes).Include(p=> p.CommunityWorks).Include(p => p.Manager).ToListAsync());
        }

        public async Task<IActionResult> Groupby()
        {
            var g = from a in _context.Association.Include(a=>a.CommunityWorks).Include(a => a.Manager)
                    group a by a.Purposes
                    into ap
                    select ap;
           return View("Index",g.ToListAsync());
        }



        // GET: Associations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var association = await _context.Association.Include(a=>a.Purposes).Include(a=>a.CommunityWorks).Include(a=>a.Manager)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (association == null)
            {
                return NotFound();
            }

            return View(association);
        }

        // GET: Associations/Create
        public IActionResult Create()
        {
            ViewData["Purposes"] = new SelectList(_context.Set<Purpose>(),"Id","Name" );
            ViewData["CommunityWorks"] = new SelectList(_context.Set<CommunityWorks>(),"Id","Description");
            return View();
        }

        // POST: Associations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,City,PurposeName,CommunityWorks,ManagerName")] Association association)
        {
            if (ModelState.IsValid)
            {
                _context.Add(association);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Purpose"] = new SelectList(_context.Purpose, "Id", "Name");
            ViewData["CommunityWorks"] = new SelectList(_context.Set<CommunityWorks>(), "Id", "Description");

            return View(association);
        }

        // GET: Associations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var association = await _context.Association.FindAsync(id);
            if (association == null)
            {
                return NotFound();
            }
            return View(association);
        }

        // POST: Associations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,City")] Association association)
        {
            if (id != association.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(association);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssociationExists(association.Id))
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
            ViewData["Purpose"] = new SelectList(_context.Purpose, "Id", "Name");
            ViewData["CommunityWorks"] = new SelectList(_context.Set<CommunityWorks>(), "Id", "Description");
            return View(association);
        }

        // GET: Associations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var association = await _context.Association
                .FirstOrDefaultAsync(m => m.Id == id);
            if (association == null)
            {
                return NotFound();
            }

            return View(association);
        }

        // POST: Associations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var association = await _context.Association.FindAsync(id);
            _context.Association.Remove(association);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssociationExists(int id)
        {
            return _context.Association.Any(e => e.Id == id);
        }
    }
}
