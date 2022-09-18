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
    public class productcategoriesController : Controller
    {
        private readonly HRContext _context;

        public productcategoriesController(HRContext context)
        {
            _context = context;
        }

        // GET: productcategories
        public async Task<IActionResult> Index()
        {
            //return _context.productcategories != null ?

            //  View(await _context.productcategories.ToListAsync()) :
            //Problem("Entity set 'HRContext.productcategories' is null.");
            var res = from t in _context.productcategories
                      select t;
            return View(res);
        }
        public ActionResult productcategory()
        {
            return _context.productcategories != null ?
                View(_context.productcategories.ToList()) :
                Problem("Entity set 'HRContext.productcategories' is null.");
            
        }

        // GET: productcategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.productcategories == null)
            {
                return NotFound();
            }

            var productcategory = await _context.productcategories
                .FirstOrDefaultAsync(m => m.id == id);
            if (productcategory == null)
            {
                return NotFound();
            }

            return View(productcategory);
        }

        // GET: productcategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: productcategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,description,image")] productcategory productcategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productcategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productcategory);
        }

        // GET: productcategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.productcategories == null)
            {
                return NotFound();
            }

            var productcategory = await _context.productcategories.FindAsync(id);
            if (productcategory == null)
            {
                return NotFound();
            }
            return View(productcategory);
        }

        // POST: productcategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,description,image")] productcategory productcategory)
        {
            if (id != productcategory.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productcategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!productcategoryExists(productcategory.id))
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
            return View(productcategory);
        }

        // GET: productcategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.productcategories == null)
            {
                return NotFound();
            }

            var productcategory = await _context.productcategories
                .FirstOrDefaultAsync(m => m.id == id);
            if (productcategory == null)
            {
                return NotFound();
            }

            return View(productcategory);
        }

        // POST: productcategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.productcategories == null)
            {
                return Problem("Entity set 'HRContext.productcategories'  is null.");
            }
            var productcategory = await _context.productcategories.FindAsync(id);
            if (productcategory != null)
            {
                _context.productcategories.Remove(productcategory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool productcategoryExists(int id)
        {
          return _context.productcategories.Any(e => e.id == id);
        }
    }
}
