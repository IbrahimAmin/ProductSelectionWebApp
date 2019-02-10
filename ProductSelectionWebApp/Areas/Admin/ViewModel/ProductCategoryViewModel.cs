using ProductSelectionWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductSelectionWebApp.Areas.Admin.ViewModel
{
    public class ProductCategoryViewModel
    {
        public ProductCategory ProductCategory { get; set; }
        public IEnumerable<ProductCategory> ProductCategoryList { get; set; }
    }
}
