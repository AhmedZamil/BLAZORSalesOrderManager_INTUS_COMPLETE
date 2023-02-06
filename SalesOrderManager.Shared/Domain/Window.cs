using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrderManager.Shared.Domain
{
    public class Window
    {
        public int WindowId { get; set; }

        public int? OrderId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Window name is too long.")]
        public string Name { get; set; } = string.Empty;
        public int? QuantityOfWindows { get; set; }
        public int? TotalSubElements { get; set; }

        
        public List<SubElement> SubElements { get; set; }

    }
}
