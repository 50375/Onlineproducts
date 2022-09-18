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
    public class producttypesController : Controller
    {
        private readonly HRContext _context;

        public producttypesController(HRContext context)
        {
            _context = context;
        }

        // GET: producttypes
        public async Task<IActionResult> Index()
        {
            var hRContext = _context.producttypes.Include(p => p.categ);
            return View(await hRContext.ToListAsync());
        }
        public ActionResult productlist(int id)
        {
            var hrcontext=_context.producttypes.Include(p => p.categ).Where(a=>a.categID==id);
            return View(hrcontext.ToList());
        }

        // GET: producttypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.producttypes == null)
            {
                return NotFound();
            }

            var producttype = await _context.producttypes
                .Include(p => p.categ)
                .FirstOrDefaultAsync(m => m.id == id);
            if (producttype == null)
            {
                return NotFound();
            }

            return View(producttype);
        }

        // GET: producttypes/Create
        public IActionResult Create()
        {
            ViewData["categID"] = new SelectList(_context.productcategories, "id", "id");
            return View();
        }

        // POST: producttypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,productname,categID,price")] producttype producttype)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producttype);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["categID"] = new SelectList(_context.productcategories, "id", "id", producttype.categID);
            return View(producttype);
        }

        // GET: producttypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.producttypes == null)
            {
                return NotFound();
            }

            var producttype = await _context.producttypes.FindAsync(id);
            if (producttype == null)
            {
                return NotFound();
            }
            ViewData["categID"] = new SelectList(_context.productcategories, "id", "id", producttype.categID);
            return View(producttype);
        }

        // POST: producttypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,productname,categID,price")] producttype producttype)
        {
            if (id != producttype.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producttype);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!producttypeExists(producttype.id))
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
            ViewData["categID"] = new SelectList(_context.productcategories, "id", "id", producttype.categID);
            return View(producttype);
        }

        // GET: producttypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.producttypes == null)
            {
                return NotFound();
            }

            var producttype = await _context.producttypes
                .Include(p => p.categ)
                .FirstOrDefaultAsync(m => m.id == id);
            if (producttype == null)
            {
                return NotFound();
            }

            return View(producttype);
        }

        // POST: producttypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.producttypes == null)
            {
                return Problem("Entity set 'HRContext.producttypes'  is null.");
            }
            var producttype = await _context.producttypes.FindAsync(id);
            if (producttype != null)
            {
                _context.producttypes.Remove(producttype);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool producttypeExists(int id)
        {
          return _context.producttypes.Any(e => e.id == id);
        }
    }
}
