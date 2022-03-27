using eshop.DAL;
using eshop.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eshop.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext db;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IWebHostEnvironment env;

        public AccountController(AppDbContext _db, UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager, RoleManager<IdentityRole> _roleManager, IWebHostEnvironment _env)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
            env = _env;
            db = _db;
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult AccessDenied()
        {
            return Content("No Access");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel lvm)
        {
            if (!ModelState.IsValid) return View();

            AppUser loggingUser = await userManager.FindByNameAsync(lvm.UserName);
            if (loggingUser == null)
            {
                ModelState.AddModelError("", "Email or password is wrong!");
                return View(lvm);
            };


            Microsoft.AspNetCore.Identity.SignInResult signInResult = await signInManager.PasswordSignInAsync(loggingUser, lvm.Password, lvm.KeepMeLoggedIn, true);
            if (signInResult.IsLockedOut)
            {
                ModelState.AddModelError("", "You are locked out!");
                return View(lvm);
            }
            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "Email or password is wrong!");
                return View(lvm);
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel rvm)
        {
            if (!ModelState.IsValid) return View();

            AppUser newUser = new AppUser
            {
                FullName = rvm.Name + " " + rvm.Surname,
                Email = rvm.Email,
                UserName = rvm.UserName,
            };

            IdentityResult identityResult = await userManager.CreateAsync(newUser, rvm.Password);

            if (!identityResult.Succeeded)
            {
                foreach (IdentityError error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(rvm);
            }

            await userManager.AddToRoleAsync(newUser, "Member");

            await signInManager.SignInAsync(newUser, true);

            if ((await userManager.GetRolesAsync(newUser))[0] == "Admin")
            {
                return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
            }

            return RedirectToAction("Index", "Home");
        }
        //public async Task<IActionResult> InitRoles()
        //{
        //    await roleManager.CreateAsync(new IdentityRole("Admin"));
        //    await roleManager.CreateAsync(new IdentityRole("Member"));
        //    return Content("Ok");
        //}
    }
}
