using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TermProject.Models;

namespace TermProject.Controllers
{
    public class LoyaltyController : Controller
    {
        private readonly PizzaContext _context;

        public LoyaltyController(PizzaContext context)
        {
            _context = context;
        }

        // GET: Loyalty
        public async Task<IActionResult> Index()
        {
              return _context.Loyalties != null ? 
                          View(await _context.Loyalties.ToListAsync()) :
                          Problem("Entity set 'PizzaContext.Loyalties'  is null.");
        }

        // GET: Loyalty/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Loyalties == null)
            {
                return NotFound();
            }

            var loyalty = await _context.Loyalties
                .FirstOrDefaultAsync(m => m.ID == id);
            if (loyalty == null)
            {
                return NotFound();
            }

            return View(loyalty);
        }

        // GET: Loyalty/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Loyalty/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,City,State,Email,PhoneNumber")] Loyalty loyalty)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loyalty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loyalty);
        }

        // GET: Loyalty/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Loyalties == null)
            {
                return NotFound();
            }

            var loyalty = await _context.Loyalties.FindAsync(id);
            if (loyalty == null)
            {
                return NotFound();
            }
            return View(loyalty);
        }

        // POST: Loyalty/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,City,State,Email,PhoneNumber")] Loyalty loyalty)
        {
            if (id != loyalty.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loyalty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoyaltyExists(loyalty.ID))
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
            return View(loyalty);
        }

        // GET: Loyalty/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Loyalties == null)
            {
                return NotFound();
            }

            var loyalty = await _context.Loyalties
                .FirstOrDefaultAsync(m => m.ID == id);
            if (loyalty == null)
            {
                return NotFound();
            }

            return View(loyalty);
        }

        // POST: Loyalty/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Loyalties == null)
            {
                return Problem("Entity set 'PizzaContext.Loyalties'  is null.");
            }
            var loyalty = await _context.Loyalties.FindAsync(id);
            if (loyalty != null)
            {
                _context.Loyalties.Remove(loyalty);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoyaltyExists(int id)
        {
          return (_context.Loyalties?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
