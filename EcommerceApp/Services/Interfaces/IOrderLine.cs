using EcommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Services.Interfaces
{
    interface IOrderLine
    {

        IEnumerable<OrderLine> GetAll();
        OrderLine GetById(int id);

        void Insert(OrderLine cat);
        void Update(OrderLine cat);

        void Delete(int id);

        int Count();

        void Save();






    }
}
