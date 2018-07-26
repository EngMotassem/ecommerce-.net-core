using EcommerceApp.DatabaseContext;
using EcommerceApp.Models;
using EcommerceApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Services.Reposotories
{
    public class SubCatRepo : ISubCategory
    {

        private readonly ApplicationDbContext _db;

        public SubCatRepo(ApplicationDbContext db)
        {
            _db = db;

        }
        public int Count()
        {

            return _db.SubCategory.Count();
      }

        public void Delete(int id)
        {

            var sub = GetById(id);
            if (sub != null)
            {
                _db.SubCategory.Remove(sub);
            }
        }

        public IEnumerable<SubCategory> GetAll()
        {

            return _db.SubCategory.Select(s => s);
        }

        public SubCategory GetById(int id)
        {
            return _db.SubCategory.FirstOrDefault(s => s.SubCatId == id);
        }

        public void Insert(SubCategory cat)
        {
            _db.SubCategory.Add(cat);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(SubCategory cat)
        {
            _db.SubCategory.Update(cat);
        }
    }
}
