using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FSPRETURN_TASK4.Data;
using FSPRETURN_TASK4.Models;

namespace FSPRETURN_TASK4.Controllers
{
    public class PlacedOrdersController : Controller
    {
        private readonly FSPReturn4Context _context;

        public PlacedOrdersController(FSPReturn4Context context)
        {
            _context = context;
        }

        // GET: PlacedOrders
        public async Task<IActionResult> Index()
        {
            var fSPReturn4Context = _context.PlacedOrders.Include(p => p.Customer);
            return View(await fSPReturn4Context.ToListAsync());
        }

        // GET: PlacedOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PlacedOrders == null)
            {
                return NotFound();
            }

            var placedOrder = await _context.PlacedOrders
                .Include(p => p.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (placedOrder == null)
            {
                return NotFound();
            }

            return View(placedOrder);
        }

        // GET: PlacedOrders/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id");
            return View();
        }

        // POST: PlacedOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustomerId")] PlacedOrder placedOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(placedOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", placedOrder.CustomerId);
            return View(placedOrder);
        }

        // GET: PlacedOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PlacedOrders == null)
            {
                return NotFound();
            }

            var placedOrder = await _context.PlacedOrders.FindAsync(id);
            if (placedOrder == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", placedOrder.CustomerId);
            return View(placedOrder);
        }

        // POST: PlacedOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerId")] PlacedOrder placedOrder)
        {
            if (id != placedOrder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(placedOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlacedOrderExists(placedOrder.Id))
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
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", placedOrder.CustomerId);
            return View(placedOrder);
        }

        // GET: PlacedOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PlacedOrders == null)
            {
                return NotFound();
            }

            var placedOrder = await _context.PlacedOrders
                .Include(p => p.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (placedOrder == null)
            {
                return NotFound();
            }

            return View(placedOrder);
        }

        // POST: PlacedOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PlacedOrders == null)
            {
                return Problem("Entity set 'FSPReturn4Context.PlacedOrders'  is null.");
            }
            var placedOrder = await _context.PlacedOrders.FindAsync(id);
            if (placedOrder != null)
            {
                _context.PlacedOrders.Remove(placedOrder);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlacedOrderExists(int id)
        {
          return (_context.PlacedOrders?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
