using eshop.DAL;
using eshop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eshop.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext db;

        public HomeController(AppDbContext _db)
        {
            db = _db;
        }
        public async Task<IActionResult> Index()
        {
            HomeViewModel hvm = new HomeViewModel();
            hvm.categories = await db.Categories.Include(x => x.SubCategories).Where(x => x.IsFeatured == true).Take(6).ToListAsync();
            hvm.products = await db.Products.Include(x => x.ProductImages).Include(x=>x.SubCategory).OrderByDescending(x => x.Id).Take(8).ToListAsync();
            return View(hvm);
        }
    }
}
