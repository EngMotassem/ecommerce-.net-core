using EcommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Services.Interfaces
{
    public interface IAuth
    {


        Task<User> Register(User user, string password);

        Task<User> Login(string  username, string password);


        Task<bool> IsUserExistAsync(string username);


    }
}
