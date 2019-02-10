using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductSelectionWebApp.Models
{
    public class AuditableEntity
    {
        //public string CreatedBy { get; set; }
        public DateTime? CreatedOnUtc { get; set; }

        //public string UpdatedBy { get; set; }
        public DateTime? UpdatedOnUtc { get; set; }
    }
}
