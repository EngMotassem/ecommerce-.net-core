using EcommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Services.Interfaces
{
    interface ISubCategory
    {

        IEnumerable<SubCategory> GetAll();
        SubCategory GetById(int id);

        void Insert(SubCategory cat);
        void Update(SubCategory cat);

        void Delete(int id);

        int Count();

        void Save();






    }
}
