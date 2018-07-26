using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Services.ViewModels.Account
{
    public class ApplicationUserListVm
    {
        public string Email { get; set; }

        public List<IdentityUserRole<string>> Roles{ get; set; }
    }
}
