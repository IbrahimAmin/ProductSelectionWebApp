using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductSelectionWebApp.Models
{
    public class ProductCategory : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public string Image { get; set; }

        [Display(Name = "Building Area")]
        public int BuildingAreaId { get; set; }

       
        [ForeignKey("BuildingAreaId")]
        public virtual BuildingArea BuildingArea { get; set; }


    }
}
