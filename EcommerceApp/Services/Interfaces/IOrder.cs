using EcommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Services.Interfaces
{
    interface IOrder
    {

        IEnumerable<Order> GetAll();
        Order GetById(int id);

        void Insert(Order cat);
        void Update(Order cat);

        void Delete(int id);

       // int Count();

        void Save();






    }
}
