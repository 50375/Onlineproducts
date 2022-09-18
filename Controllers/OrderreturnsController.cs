using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Onlineproducts.Models;

namespace Onlineproducts.Controllers
{
    public class OrderreturnsController : Controller
    {
        private readonly HRContext _context;

        public OrderreturnsController(HRContext context)
        {
            _context = context;
        }

        // GET: Orderreturns
        public async Task<IActionResult> Index()
        {
              return View(await _context.Orderreturns.ToListAsync());
        }
        public ActionResult Orderreturn()
        {

            var res = from t in _context.Orders
                      select t;
            return View(res);
        }

        // GET: Orderreturns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Orderreturns == null)
            {
                return NotFound();
            }

            var orderreturn = await _context.Orderreturns
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orderreturn == null)
            {
                return NotFound();
            }

            return View(orderreturn);
        }

        // GET: Orderreturns/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orderreturns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,OrderName")] Orderreturn orderreturn)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderreturn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orderreturn);
        }

        // GET: Orderreturns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Orderreturns == null)
            {
                return NotFound();
            }

            var orderreturn = await _context.Orderreturns.FindAsync(id);
            if (orderreturn == null)
            {
                return NotFound();
            }
            return View(orderreturn);
        }

        // POST: Orderreturns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,OrderName")] Orderreturn orderreturn)
        {
            if (id != orderreturn.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderreturn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderreturnExists(orderreturn.OrderId))
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
            return View(orderreturn);
        }

        // GET: Orderreturns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Orderreturns == null)
            {
                return NotFound();
            }

            var orderreturn = await _context.Orderreturns
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orderreturn == null)
            {
                return NotFound();
            }

            return View(orderreturn);
        }

        // POST: Orderreturns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Orderreturns == null)
            {
                return Problem("Entity set 'HRContext.Orderreturns'  is null.");
            }
            var orderreturn = await _context.Orderreturns.FindAsync(id);
            if (orderreturn != null)
            {
                _context.Orderreturns.Remove(orderreturn);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderreturnExists(int id)
        {
          return _context.Orderreturns.Any(e => e.OrderId == id);
        }
    }
}
