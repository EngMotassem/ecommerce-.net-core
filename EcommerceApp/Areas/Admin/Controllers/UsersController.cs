using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceApp.DatabaseContext;
using EcommerceApp.Models;
using EcommerceApp.Services.Interfaces;
using EcommerceApp.Services.ViewModels.Account;
using EcommerceApp.Services.ViewModels.AdminVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EcommerceApp.Areas.Admin.Controllers
{

    [Area("Admin")]

    [Route("[area]/[controller]/[action]")]

    public class UsersController : Controller
    {

        private readonly ICustomer _customerRepo;
        private readonly UserManager<Customer> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;


        private readonly SignInManager<Customer> _signInManager;

        private readonly IServiceProvider _serviceProvider;

        public UsersController(UserManager<Customer> userManager, RoleManager<ApplicationRole> roleManager,

             
            SignInManager<Customer> signInManager,ICustomer customerRepo, IServiceProvider serviceProvider)
        {

            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _customerRepo = customerRepo;
            _serviceProvider = serviceProvider;
        }


        public IActionResult Index()
        {

            var customers = _customerRepo.GetAll();
            return View(customers);
           
        }
        [HttpGet]

        public IActionResult Create()
        {

            var createUserVM = new CreateUserVM
            {

                //Customers = new Customer(),

                AppRoles = _customerRepo.GetAllRoles().ToList()

            };
           // var roles = _roleManager.Roles.ToList();


           // ViewBag.roles = roles;
            return View(createUserVM);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(CreateUserVM createUserVM)
        {
            {
                if (ModelState.IsValid)
                {
                    var customer = new Customer { UserName = createUserVM.Email, Email = createUserVM.Email };
                    var result = await _userManager.CreateAsync(customer, createUserVM.Password);

                    if (result.Succeeded)
                    {
                        if (!_roleManager.RoleExistsAsync(createUserVM.RoleName).Result)
                        {
                            ApplicationRole role = new ApplicationRole();
                            role.Name = createUserVM.RoleName;

                            IdentityResult roleResult = _roleManager.CreateAsync(role).Result;

                            if (!roleResult.Succeeded)
                            {
                                ModelState.AddModelError("", "Somethings went wrong !");
                                return View(createUserVM);
                            }
                        }
                        customer.RoleName = createUserVM.RoleName;

                        customer.Password = createUserVM.Password;

                        _userManager.AddToRoleAsync(customer, createUserVM.RoleName).Wait();
                        await _signInManager.SignInAsync(customer, isPersistent: false);
                        return RedirectToAction("Index");
                    }
                }

                return View(createUserVM);
            }




           



        }

        [HttpGet]

        public IActionResult CreateRole()
        {

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> CreateRole(ApplicationRole applicationRole)
        {


            //adding custom roles


            var role = new ApplicationRole();
            role.Name = applicationRole.Name;
            await _roleManager.CreateAsync(role);

            return RedirectToAction("Index");


        }











    }
}
        

       


    
