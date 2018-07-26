using EcommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Services.Interfaces
{
    public interface IPicture
    {

        IEnumerable<Picture> GetAll();
        Picture GetById(int id);

        void Insert(Picture cat);
        void Update(Picture cat);

        void Delete(int id);

        //int Count();

        void Save();






    }
}
