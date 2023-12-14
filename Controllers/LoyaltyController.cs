using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TermProject.Models;
using Microsoft.AspNetCore.Authorization;

namespace TermProject.Controllers
{
    [Authorize]
    public class LoyaltyController : Controller
    {
        private readonly PizzaContext _context;

        public LoyaltyController(PizzaContext context)
        {
            _context = context;
        }

        // GET: Loyalty
        [AllowAnonymous]
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber) 
        {
            var loyalties = from m in _context.Loyalties.Include(a => a.Menu)
                            select m;

            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;
            
            if(_context.Loyalties == null)
            {
                return Problem("No results");
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                loyalties = loyalties.Where(m => m.FirstName.Contains(searchString)
                || m.LastName.Contains(searchString)
                || m.City.Contains(searchString)
                || m.State.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    loyalties = loyalties.OrderByDescending(m => m.LastName);
                    break;
                default:
                    loyalties = loyalties.OrderBy(m => m.LastName);
                    break;
            }

            int pageSize = 3;
            return View(await PaginatedList<Loyalty>.CreateAsync(loyalties.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Loyalty/Details/5
        [AllowAnonymous]
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
