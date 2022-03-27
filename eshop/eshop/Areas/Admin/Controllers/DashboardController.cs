using eshop.Areas.Admin.Models;
using eshop.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eshop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly AppDbContext db;
        public DashboardController(AppDbContext _db)
        {
            db = _db;
        }
        public async Task<IActionResult> Index()
        {
            DashboardViewModel dvm = new DashboardViewModel();
            dvm.UserCount = await db.Users.CountAsync();
            dvm.CategoryCount = await db.Categories.CountAsync();
            dvm.SubcategoryCount = await db.SubCategories.CountAsync();
            return View(dvm);
        }
    }
}
