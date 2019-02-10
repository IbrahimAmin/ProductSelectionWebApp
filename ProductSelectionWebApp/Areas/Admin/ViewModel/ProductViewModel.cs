using ProductSelectionWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductSelectionWebApp.Areas.Admin.ViewModel
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public InclusionType InclusionType { get; set; }
        public IEnumerable<Product> ProductList { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<Range> Ranges { get; set; }
        public IEnumerable<InclusionType> InclusionTypes { get; set; }
        public IEnumerable<ProductCategory> ProductCategories { get; set; }
    }
}
