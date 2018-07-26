using EcommerceApp.DatabaseContext;
using EcommerceApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Services.ViewModels.AdminVM
{
    public class CreateUserVM
    {
        public string UserName { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        

        [EmailAddress]
        public string Email { get; set; }


        public string RoleName { get; set; }




        public List<ApplicationRole> AppRoles { get; set; }






    }
}
