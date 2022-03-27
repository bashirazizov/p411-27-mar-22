using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eshop.Areas.Admin.Models
{
    public class DashboardViewModel
    {
        public int UserCount { get; set; }
        public int CategoryCount { get; set; }
        public int SubcategoryCount { get; set; }
    }
}
