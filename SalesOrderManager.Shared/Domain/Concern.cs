using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrderManager.Shared.Domain
{
    public class Concern
    {
        public int ConcernId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
