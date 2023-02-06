using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrderManager.Shared.Domain
{
    public class SubElement
    {
        public int SubElementId { get; set; }
        public int? WindowId { get; set; }

        [Required]
        public string ElementType { get; set; }
        public int Element { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
    }
}
