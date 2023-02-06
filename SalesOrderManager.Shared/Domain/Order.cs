using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrderManager.Shared.Domain
{
    public class Order
    {
        public int OrderId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Order name is too long.")]
        public string Name { get; set; } = string.Empty;

        public int? StateId { get; set; }
        public State State { get; set; }
        public List<Window> Windows { get; set; }
    }
}
