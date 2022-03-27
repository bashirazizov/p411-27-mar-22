using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eshop.Models
{
    public class Category : BaseEntity
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }
        public string Image { get; set; }
        public bool IsFeatured { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public List<SubCategory> SubCategories { get; set; }

    }
}
