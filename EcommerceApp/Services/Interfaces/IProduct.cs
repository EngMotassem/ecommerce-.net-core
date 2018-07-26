using EcommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Services.Interfaces
{
    public interface IProduct
    {

        IEnumerable<Product> GetAll();
        Product GetById(int id);

        void Insert(Product cat);
        void Update(Product cat);

        void Delete(int id);

        int Count();

        void Save();






    }
}
