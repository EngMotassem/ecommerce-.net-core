using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Services.ViewModels.Account
{
    public class AddUserVM
    {

        public string UserName { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage ="please add role to this user")]

        public string  RoleName { get; set; }
    }
}
