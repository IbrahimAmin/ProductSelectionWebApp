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
    public class BuildingAreasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BuildingAreasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Temp/BuildingAreas
        public async Task<IActionResult> Index()
        {
            return View(await _context.BuildingArea.ToListAsync());
        }

        // GET: Temp/BuildingAreas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buildingArea = await _context.BuildingArea
                .FirstOrDefaultAsync(m => m.Id == id);
            if (buildingArea == null)
            {
                return NotFound();
            }

            return View(buildingArea);
        }

        // GET: Temp/BuildingAreas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Temp/BuildingAreas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DisplayOrder,CreatedOnUtc,UpdatedOnUtc")] BuildingArea buildingArea)
        {
            if (ModelState.IsValid)
            {
                _context.Add(buildingArea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(buildingArea);
        }

        // GET: Temp/BuildingAreas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buildingArea = await _context.BuildingArea.FindAsync(id);
            if (buildingArea == null)
            {
                return NotFound();
            }
            return View(buildingArea);
        }

        // POST: Temp/BuildingAreas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DisplayOrder,CreatedOnUtc,UpdatedOnUtc")] BuildingArea buildingArea)
        {
            if (id != buildingArea.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buildingArea);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuildingAreaExists(buildingArea.Id))
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
            return View(buildingArea);
        }

        // GET: Temp/BuildingAreas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buildingArea = await _context.BuildingArea
                .FirstOrDefaultAsync(m => m.Id == id);
            if (buildingArea == null)
            {
                return NotFound();
            }

            return View(buildingArea);
        }

        // POST: Temp/BuildingAreas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var buildingArea = await _context.BuildingArea.FindAsync(id);
            _context.BuildingArea.Remove(buildingArea);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuildingAreaExists(int id)
        {
            return _context.BuildingArea.Any(e => e.Id == id);
        }
    }
}
