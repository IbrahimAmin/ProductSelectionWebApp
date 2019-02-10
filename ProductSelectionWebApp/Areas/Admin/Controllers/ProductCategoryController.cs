using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductSelectionWebApp.Areas.Admin.ViewModel;
using ProductSelectionWebApp.Data;
using ProductSelectionWebApp.Utility;

namespace ProductSelectionWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductCategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly HostingEnvironment _hostingEnvironment;

        [BindProperty]
        public ProductCategoryViewModel ProductCategoryVM { get; set; }

        public ProductCategoryController(ApplicationDbContext db, HostingEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;

            ProductCategoryVM = new ProductCategoryViewModel
            {               
                ProductCategory = new Models.ProductCategory(),
                ProductCategoryList = _db.ProductCategory.ToList(),
                BuildingAreasList = _db.BuildingArea.ToList()                
            };

        }

        // Get: Products Category/ Index
        public IActionResult Index()
        {

            //var productCategory = _db.ProductCategory.Include(m => m.BuildingArea).ToList();

            //return View(productCategory);

            ProductCategoryViewModel ProductCategoryVM = new ProductCategoryViewModel
            {
                ProductCategoryList = _db.ProductCategory.Include(m => m.BuildingArea).ToList(),
                BuildingAreasList = _db.BuildingArea.OrderBy(m => m.DisplayOrder).ToList()
            };
            return View(ProductCategoryVM);
        }

        // Get: Products Category/ Create
        public IActionResult Create()
        {
            return View(ProductCategoryVM);
        }

        // Post: Products Category/ Create
        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> CreatePost ()
        {
            if(!ModelState.IsValid)
            {
                return View(ProductCategoryVM);
            }

            _db.ProductCategory.Add(ProductCategoryVM.ProductCategory);
            await _db.SaveChangesAsync();

            // Image Being Saves

            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            var ProductCategoryFromDb = _db.ProductCategory.Find(ProductCategoryVM.ProductCategory.Id);

            if (files.Count != 0)
            {
                // Image has been uploaded
                var uploads = Path.Combine(webRootPath, StaticDetails.CategoryImage);
                var extension = Path.GetExtension(files[0].FileName);

                using (var filestream = new FileStream(Path.Combine(uploads, ProductCategoryVM.ProductCategory.Id + extension), FileMode.Create))
                {
                    files[0].CopyTo(filestream);
                }

                ProductCategoryFromDb.Image = @"\" + StaticDetails.CategoryImage + @"\" + ProductCategoryVM.ProductCategory.Id + extension;

            }
            else
            {
                // When user does not upload image
                var uploads = Path.Combine(webRootPath, StaticDetails.CategoryImage + @"\" + StaticDetails.DefaultProductImage);
                System.IO.File.Copy(uploads, webRootPath + @"\" + StaticDetails.CategoryImage + @"\" + ProductCategoryVM.ProductCategory.Id + ".jpg");
                ProductCategoryFromDb.Image = @"\" + StaticDetails.CategoryImage + @"\" + ProductCategoryVM.ProductCategory.Id + ".jpg";


            }
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));





        }




    }
}