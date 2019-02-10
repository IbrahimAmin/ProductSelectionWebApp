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
        public string Name { get; set; }
        public string Image { get; set; }




        [Display(Name = "Category")]
        public int ProductCategoryId { get; set; }

        [ForeignKey("BuildingAreaId")]
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
