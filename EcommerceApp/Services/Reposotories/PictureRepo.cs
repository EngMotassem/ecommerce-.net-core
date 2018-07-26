using EcommerceApp.DatabaseContext;
using EcommerceApp.Models;
using EcommerceApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Services.Reposotories
{
    public class PictureRepo : IPicture
    {

        private readonly ApplicationDbContext _db;

        public PictureRepo(ApplicationDbContext db)
        {
            _db = db;

        }
        public int Count()
        {

            return _db.Picture.Count();
      }

        public void Delete(int id)
        {

            var product = GetById(id);
            if (product != null)
            {
                _db.Picture.Remove(product);
            }
        }

        public IEnumerable<Picture> GetAll()
        {

            return _db.Picture.Select(s => s);
        }

        public Picture GetById(int id)
        {
            return _db.Picture.FirstOrDefault(s => s.PictureId == id);
        }

        public void Insert(Picture cat)
        {
            _db.Picture.Add(cat);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Picture cat)
        {
            _db.Picture.Update(cat);
        }
    }
}
