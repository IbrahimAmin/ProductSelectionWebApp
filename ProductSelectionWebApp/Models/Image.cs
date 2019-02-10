using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductSelectionWebApp.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
        public bool IsDefault { get; set; }
        public bool IsActive { get; set; }  
    }
}
