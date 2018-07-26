using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceApp.DatabaseContext;
using EcommerceApp.Models;
using EcommerceApp.Services.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<Customer> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SignInManager<Customer> _signInManager;


        public AccountController(UserManager<Customer> userManager, RoleManager<ApplicationRole> roleManager, SignInManager<Customer> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }




        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                var customer = new Customer { UserName = registerVM.Email, Email = registerVM.Email };
                var result = await _userManager.CreateAsync(customer, registerVM.Password);

                if (result.Succeeded)
                {
                    if (!_roleManager.RoleExistsAsync("SiteUser").Result)
                    {
                        ApplicationRole role = new ApplicationRole();
                        role.Name = "SiteUser";

                        IdentityResult roleResult = _roleManager.CreateAsync(role).Result;

                        if (!roleResult.Succeeded)
                        {
                            ModelState.AddModelError("", "Somethings went wrong !");
                            return View(registerVM);
                        }
                    }
                    customer.RoleName = "site user";

                    _userManager.AddToRoleAsync(customer, "SiteUser").Wait();
                    await _signInManager.SignInAsync(customer, isPersistent: false);
                    return RedirectToAction("Login", "Account");
                }
            }

            return View(registerVM);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Login(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                var result = _signInManager.PasswordSignInAsync(
                    loginVM.Email,
                    loginVM.Password,
                    loginVM.RememberMe,
                    false).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Somethings went wrong !");
                }

            }
            return View(loginVM);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }


    }
}