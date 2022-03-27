using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eshop.Models
{
    public class HomeViewModel
    {
        public List<Category> categories { get; set; }
        public List<Product> products { get; set; }
    }
}
