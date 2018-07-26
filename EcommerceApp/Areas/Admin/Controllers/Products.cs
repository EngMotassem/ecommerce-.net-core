using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EcommerceApp.Models;
using EcommerceApp.Services.Interfaces;
using EcommerceApp.Services.ViewModels.AdminVM;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EcommerceApp.Areas.Admin.Controllers
{
    [Area("Admin")]

    [Route("[area]/[controller]/[action]")]
    public class Products : Controller
    {

        private readonly ICategory _categoryRepository;

        private readonly IProduct _productRepository;


        private readonly IPicture _pictureRepository;


        private IHostingEnvironment _environment;



        public Products(ICategory categoryRepository, IProduct productRepository, 
            IPicture pictureRepository, IHostingEnvironment environment)
        {


            _categoryRepository = categoryRepository;
            _productRepository = productRepository;

            _pictureRepository = pictureRepository;

            _environment = environment;

        }





        // GET: /<controller>/
        public IActionResult Index()
        {
            var prod = _productRepository.GetAll();
            return View(prod);
        }
        [HttpGet]

        public IActionResult Create()
        {

            var productVM = new ProductsVM
            {

               // Products = new Product{},
                Categories = _categoryRepository.GetAll().ToList()

            };

            return View(productVM);
        }
        [HttpPost]
        public IActionResult Create(ProductsVM productVM)
        {




            if (!ModelState.IsValid)
            {
                return View();


            }

            //Create Image

            if (productVM.Products.ProductImage?.Length > 0)
            {
               // productVM.Products.ProductImage.OpenReadStream
                var uploads = Path.Combine(_environment.WebRootPath, "uploads");

                using (var fileStream = new FileStream(Path.Combine(uploads, productVM.Products.ProductImage.FileName), FileMode.Create))
                {
                    productVM.Products.ProductImage.CopyTo(fileStream);
                }
               productVM.Products.ProductImagePath = productVM.Products.ProductImage.FileName.ToString();
            }



            _productRepository.Insert(productVM.Products);
            try
           {
                _productRepository.Save();
            }
            catch(Exception e)
            {

              return View(e);
            }

            productVM.Categories = _categoryRepository.GetAll().ToList();



            return RedirectToAction("Index","Category");


           // return View(productVM);
        }




    }
}
