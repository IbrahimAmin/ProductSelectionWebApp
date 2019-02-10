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
    public class RangesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RangesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Temp/Ranges
        public async Task<IActionResult> Index()
        {
            return View(await _context.Range.ToListAsync());
        }

        // GET: Temp/Ranges/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var range = await _context.Range
                .FirstOrDefaultAsync(m => m.Id == id);
            if (range == null)
            {
                return NotFound();
            }

            return View(range);
        }

        // GET: Temp/Ranges/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Temp/Ranges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Rnage")] Range range)
        {
            if (ModelState.IsValid)
            {
                _context.Add(range);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(range);
        }

        // GET: Temp/Ranges/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var range = await _context.Range.FindAsync(id);
            if (range == null)
            {
                return NotFound();
            }
            return View(range);
        }

        // POST: Temp/Ranges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Rnage")] Range range)
        {
            if (id != range.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(range);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RangeExists(range.Id))
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
            return View(range);
        }

        // GET: Temp/Ranges/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var range = await _context.Range
                .FirstOrDefaultAsync(m => m.Id == id);
            if (range == null)
            {
                return NotFound();
            }

            return View(range);
        }

        // POST: Temp/Ranges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var range = await _context.Range.FindAsync(id);
            _context.Range.Remove(range);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RangeExists(int id)
        {
            return _context.Range.Any(e => e.Id == id);
        }
    }
}
