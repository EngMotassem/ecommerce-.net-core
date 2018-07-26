using EcommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Services.Interfaces
{
    interface ICartItem
    {

        IEnumerable<CartItem> GetAll();
        CartItem GetById(int id);

        void Insert(CartItem cat);
        void Update(CartItem cat);

        void Delete(int id);

        int Count();

        void Save();






    }
}
