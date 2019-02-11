using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductSelectionWebApp.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Display(Name = "Model Name")]
        public string ModelName { get; set; }

        [Display(Name = "Model Number")]
        public string ModelNumber { get; set; }

        public bool IsActive { get; set; }
        public bool IsDefault { get; set; }

        public string Image { get; set; }

        public string Note{ get; set; }





        [Display(Name = "Category")]
        public int ProductCategoryId { get; set; }

        [ForeignKey("ProductCategoryId")]
        [Display(Name = "Category")]
        public virtual ProductCategory ProductCategory { get; set; }

        [Display(Name = "Brand")]
        public int BrandId { get; set; }

        [ForeignKey("BrandId")]
        public virtual Brand Brand { get; set; }

        [Display(Name = "Range")]
        public int RangeId { get; set; }

        [ForeignKey("RangeId")]
        public virtual Range Range { get; set; }


        [Display(Name = "Inclusion Type")]
        public int InclusionTypeId { get; set; }

        [ForeignKey("InclusionTypeId")]
        public virtual InclusionType InclusionType { get; set; }





    }
}
