using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductSelectionWebApp.Data;
using ProductSelectionWebApp.Models;

namespace ProductSelectionWebApp.Areas.Temp.Controllers
{
    [Area("Temp")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Temp/Products
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Product.Include(p => p.Brand).Include(p => p.InclusionType).Include(p => p.ProductCategory).Include(p => p.Range);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Temp/Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.Brand)
                .Include(p => p.InclusionType)
                .Include(p => p.ProductCategory)
                .Include(p => p.Range)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Temp/Products/Create
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.Brand, "Id", "Id");
            ViewData["InclusionTypeId"] = new SelectList(_context.InclusionType, "Id", "Id");
            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategory, "Id", "Id");
            ViewData["RangeId"] = new SelectList(_context.Range, "Id", "Id");
            return View();
        }

        // POST: Temp/Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ModelName,ModelNumber,IsActive,IsDefault,Image,Note,ProductCategoryId,BrandId,RangeId,InclusionTypeId")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.Brand, "Id", "Id", product.BrandId);
            ViewData["InclusionTypeId"] = new SelectList(_context.InclusionType, "Id", "Id", product.InclusionTypeId);
            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategory, "Id", "Id", product.ProductCategoryId);
            ViewData["RangeId"] = new SelectList(_context.Range, "Id", "Id", product.RangeId);
            return View(product);
        }

        // GET: Temp/Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.Brand, "Id", "Id", product.BrandId);
            ViewData["InclusionTypeId"] = new SelectList(_context.InclusionType, "Id", "Id", product.InclusionTypeId);
            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategory, "Id", "Id", product.ProductCategoryId);
            ViewData["RangeId"] = new SelectList(_context.Range, "Id", "Id", product.RangeId);
            return View(product);
        }

        // POST: Temp/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ModelName,ModelNumber,IsActive,IsDefault,Image,Note,ProductCategoryId,BrandId,RangeId,InclusionTypeId")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            ViewData["BrandId"] = new SelectList(_context.Brand, "Id", "Id", product.BrandId);
            ViewData["InclusionTypeId"] = new SelectList(_context.InclusionType, "Id", "Id", product.InclusionTypeId);
            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategory, "Id", "Id", product.ProductCategoryId);
            ViewData["RangeId"] = new SelectList(_context.Range, "Id", "Id", product.RangeId);
            return View(product);
        }

        // GET: Temp/Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.Brand)
                .Include(p => p.InclusionType)
                .Include(p => p.ProductCategory)
                .Include(p => p.Range)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Temp/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}
