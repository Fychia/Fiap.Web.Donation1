using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fiap.Web.Donation1.Data;
using Fiap.Web.Donation1.Models;

namespace Fiap.Web.Donation1.Controllers
{
    public class TypeProductsController : Controller
    {
        private readonly DataContext _context;

        public TypeProductsController(DataContext context)
        {
            _context = context;
        }

        // GET: TypeProducts
        public async Task<IActionResult> Index()
        {
              return _context.TypeProducts != null ? 
                          View(await _context.TypeProducts.ToListAsync()) :
                          Problem("Entity set 'DataContext.TypeProducts'  is null.");
        }

        // GET: TypeProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TypeProducts == null)
            {
                return NotFound();
            }

            var modelTypeProduct = await _context.TypeProducts
                .FirstOrDefaultAsync(m => m.TypeProductID == id);
            if (modelTypeProduct == null)
            {
                return NotFound();
            }

            return View(modelTypeProduct);
        }

        // GET: TypeProducts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeProductID,TypeProductName,TypeProductDescription")] ModelTypeProduct modelTypeProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modelTypeProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modelTypeProduct);
        }

        // GET: TypeProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TypeProducts == null)
            {
                return NotFound();
            }

            var modelTypeProduct = await _context.TypeProducts.FindAsync(id);
            if (modelTypeProduct == null)
            {
                return NotFound();
            }
            return View(modelTypeProduct);
        }

        // POST: TypeProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TypeProductID,TypeProductName,TypeProductDescription")] ModelTypeProduct modelTypeProduct)
        {
            if (id != modelTypeProduct.TypeProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modelTypeProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModelTypeProductExists(modelTypeProduct.TypeProductID))
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
            return View(modelTypeProduct);
        }

        // GET: TypeProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TypeProducts == null)
            {
                return NotFound();
            }

            var modelTypeProduct = await _context.TypeProducts
                .FirstOrDefaultAsync(m => m.TypeProductID == id);
            if (modelTypeProduct == null)
            {
                return NotFound();
            }

            return View(modelTypeProduct);
        }

        // POST: TypeProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TypeProducts == null)
            {
                return Problem("Entity set 'DataContext.TypeProducts'  is null.");
            }
            var modelTypeProduct = await _context.TypeProducts.FindAsync(id);
            if (modelTypeProduct != null)
            {
                _context.TypeProducts.Remove(modelTypeProduct);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModelTypeProductExists(int id)
        {
          return (_context.TypeProducts?.Any(e => e.TypeProductID == id)).GetValueOrDefault();
        }
    }
}
