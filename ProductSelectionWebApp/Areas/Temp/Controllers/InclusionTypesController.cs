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
    public class InclusionTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InclusionTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Temp/InclusionTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.InclusionType.ToListAsync());
        }

        // GET: Temp/InclusionTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inclusionType = await _context.InclusionType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inclusionType == null)
            {
                return NotFound();
            }

            return View(inclusionType);
        }

        // GET: Temp/InclusionTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Temp/InclusionTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DisplayOrder,IsActive,CreatedOnUtc,UpdatedOnUtc")] InclusionType inclusionType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inclusionType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inclusionType);
        }

        // GET: Temp/InclusionTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inclusionType = await _context.InclusionType.FindAsync(id);
            if (inclusionType == null)
            {
                return NotFound();
            }
            return View(inclusionType);
        }

        // POST: Temp/InclusionTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DisplayOrder,IsActive,CreatedOnUtc,UpdatedOnUtc")] InclusionType inclusionType)
        {
            if (id != inclusionType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inclusionType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InclusionTypeExists(inclusionType.Id))
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
            return View(inclusionType);
        }

        // GET: Temp/InclusionTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inclusionType = await _context.InclusionType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inclusionType == null)
            {
                return NotFound();
            }

            return View(inclusionType);
        }

        // POST: Temp/InclusionTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inclusionType = await _context.InclusionType.FindAsync(id);
            _context.InclusionType.Remove(inclusionType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InclusionTypeExists(int id)
        {
            return _context.InclusionType.Any(e => e.Id == id);
        }
    }
}
