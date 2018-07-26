using EcommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Services.ViewModels.AdminVM
{
    public class ProductsVM
    {

        public Product Products {set;get;}

        public List<Category> Categories { set; get; }
    }
}
