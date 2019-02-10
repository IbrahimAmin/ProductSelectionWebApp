using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductSelectionWebApp.Areas.Admin.ViewModel;
using ProductSelectionWebApp.Data;
using ProductSelectionWebApp.Models;
using ProductSelectionWebApp.Utility;

namespace ProductSelectionWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly HostingEnvironment _hostingEnvironment;

        [BindProperty]
        public ProductViewModel ProductVM { get; set; }

        public ProductController(ApplicationDbContext db, HostingEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;

            ProductVM = new ProductViewModel
            {
                Product = new Models.Product(),
                ProductList =_db.Product.ToList(),
                ProductCategories=_db.ProductCategory.ToList(),
                InclusionTypes=_db.InclusionType.ToList(),
                Brands=_db.Brand.ToList()
               
            };

        }
        // GET: Admin/Products
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _db.Product.Include(p => p.Brand).Include(p => p.InclusionType).Include(p => p.ProductCategory);
            return View(await applicationDbContext.ToListAsync());
        }

        // Get: Product / Create
        public IActionResult Create()
        {
            return View(ProductVM);
        }

        // Post: Product / Create
        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost()
        {
            if (!ModelState.IsValid)
            {
                return View(ProductVM);
            }

            _db.Product.Add(ProductVM.Product);
            await _db.SaveChangesAsync();

            // Image Being Saves

            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            var ProductFromDb = _db.Product.Find(ProductVM.Product.Id);

            if (files.Count != 0)
            {
                // Image has been uploaded
                var uploads = Path.Combine(webRootPath, StaticDetails.ProductImage);
                var extension = Path.GetExtension(files[0].FileName);

                using (var filestream = new FileStream(Path.Combine(uploads, ProductVM.Product.Id + extension), FileMode.Create))
                {
                    files[0].CopyTo(filestream);
                }

                ProductFromDb.Image = @"\" + StaticDetails.ProductImage + @"\" + ProductVM.Product.Id + extension;

            }
            else
            {
                // When user does not upload image
                var uploads = Path.Combine(webRootPath, StaticDetails.ProductImage + @"\" + StaticDetails.DefaultProductImage);
                System.IO.File.Copy(uploads, webRootPath + @"\" + StaticDetails.CategoryImage + @"\" + ProductVM.ProductCategory.Id + ".jpg");
                ProductFromDb.Image = @"\" + StaticDetails.ProductImage + @"\" + ProductVM.Product.Id + ".jpg";


            }
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        // GET: Temp/Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _db.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_db.Brand, "Id", "Name", product.BrandId);
            ViewData["InclusionTypeId"] = new SelectList(_db.InclusionType, "Id", "Name", product.InclusionTypeId);
            ViewData["ProductCategoryId"] = new SelectList(_db.ProductCategory, "Id", "Name", product.ProductCategoryId);
            return View(product);
        }

        // POST: Temp/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ModelName,ModelNumber,Range,Image,ProductCategoryId,BrandId,InclusionTypeId")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(product);
                    await _db.SaveChangesAsync();
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
            ViewData["BrandId"] = new SelectList(_db.Brand, "Id", "Name", product.BrandId);
            ViewData["InclusionTypeId"] = new SelectList(_db.InclusionType, "Id", "Name", product.InclusionTypeId);
            ViewData["ProductCategoryId"] = new SelectList(_db.ProductCategory, "Id", "Name", product.ProductCategoryId);
            return View(product);
        }


        // GET: Temp/Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _db.Product
                .Include(p => p.Brand)
                .Include(p => p.InclusionType)
                .Include(p => p.ProductCategory)
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
            var product = await _db.Product.FindAsync(id);
            _db.Product.Remove(product);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _db.Product.Any(e => e.Id == id);
        }


    }
        }