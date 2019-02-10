using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using ProductSelectionWebApp.Areas.Admin.ViewModel;
using ProductSelectionWebApp.Data;
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
               
            };

        }


        public IActionResult Index()
        {
            return View(ProductVM);
        }

        // Get: Products Category/ Create
        public IActionResult Create()
        {
            return View(ProductVM);
        }

        // Post: Products Category/ Create
        //[HttpPost]
        //[ActionName("Create")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> CreatePost()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(ProductVM);
        //    }

        //    _db.ProductCategory.Add(ProductVM.ProductCategory);
        //    await _db.SaveChangesAsync();

        //    // Image Being Saves

        //    string webRootPath = _hostingEnvironment.WebRootPath;
        //    var files = HttpContext.Request.Form.Files;

        //    var ProductCategoryFromDb = _db.ProductCategory.Find(ProductVM.ProductCategory.Id);

        //    if (files.Count != 0)
        //    {
        //        // Image has been uploaded
        //        var uploads = Path.Combine(webRootPath, StaticDetails.CategoryImage);
        //        var extension = Path.GetExtension(files[0].FileName);

        //        using (var filestream = new FileStream(Path.Combine(uploads, ProductVM.ProductCategory.Id + extension), FileMode.Create))
        //        {
        //            files[0].CopyTo(filestream);
        //        }

        //        ProductCategoryFromDb.Image = @"\" + StaticDetails.CategoryImage + @"\" + ProductVM.ProductCategory.Id + extension;

        //    }
        //    else
        //    {
        //        // When user does not upload image
        //        var uploads = Path.Combine(webRootPath, StaticDetails.CategoryImage + @"\" + StaticDetails.DefaultProductImage);
        //        System.IO.File.Copy(uploads, webRootPath + @"\" + StaticDetails.CategoryImage + @"\" + ProductVM.ProductCategory.Id + ".jpg");
        //        ProductCategoryFromDb.Image = @"\" + StaticDetails.CategoryImage + @"\" + ProductVM.ProductCategory.Id + ".jpg";


        //    }
        //    await _db.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));

        //}
    }
}