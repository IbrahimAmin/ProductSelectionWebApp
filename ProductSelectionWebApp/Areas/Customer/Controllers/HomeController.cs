using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductSelectionWebApp.Areas.Admin.ViewModel;
using ProductSelectionWebApp.Data;
using ProductSelectionWebApp.Models;

namespace ProductSelectionWebApp.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _db;
        

        [BindProperty]
        public ProductCategoryViewModel ProductCategoryVM { get; set; }

        public HomeController(ApplicationDbContext db, HostingEnvironment hostingEnvironment)
        {
            _db = db;            

            ProductCategoryVM = new ProductCategoryViewModel
            {
                ProductCategory = new Models.ProductCategory(),
                ProductCategoryList = _db.ProductCategory.ToList(),
                BuildingAreasList = _db.BuildingArea.ToList()
            };

        }


        public IActionResult Index()
        {
            ProductCategoryViewModel ProductCategoryVM = new ProductCategoryViewModel
            {
                ProductCategoryList = _db.ProductCategory.Include(m => m.BuildingArea).ToList(),
                BuildingAreasList = _db.BuildingArea.OrderBy(m => m.DisplayOrder).ToList()
            };
            return View(ProductCategoryVM);
        }



        // GET: Temp/ProductCategories/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductViewModel productVM = new ProductViewModel
            {
                ProductCategory = _db.ProductCategory.FirstOrDefault(p => p.Id == id),
                ProductCategories = _db.ProductCategory.ToList(),
                InclusionTypes = _db.InclusionType.ToList(),

                ProductList = _db.Product.Include(m => m.ProductCategory).Include(m => m.InclusionType).Where(m => m.ProductCategoryId == id).ToList(),


            };
            return View(productVM);
        }


    }
}
