using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eshop.Models
{
    public class Product : BaseEntity
    {
        [Required,MaxLength(100)]
        public string Name { get; set; }
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        [NotMapped]
        public IFormFile[] ImageFiles { get; set; }
        [Required]
        public int Price { get; set; }
        public int OffPercentage { get; set; }
        public int StarCount { get; set; }
        public bool IsNew { get; set; }
    }
}
