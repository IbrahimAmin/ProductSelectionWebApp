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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
