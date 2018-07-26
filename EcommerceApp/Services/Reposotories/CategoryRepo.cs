using EcommerceApp.DatabaseContext;
using EcommerceApp.Models;
using EcommerceApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Services.Reposotories
{
    public class CategoryRepo:ICategory
    {

        private readonly ApplicationDbContext _db;
        
        public CategoryRepo(ApplicationDbContext db)
        {

            _db = db;

        }

        public int Count()
        {


            return _db.Category.Count();
            
        }

        public void Delete(int id)
        {

            var category = GetById(id);
                if(category!=null)
            {
                _db.Category.Remove(category);
            }
            
        }

        public IEnumerable<Category> GetAll()
        {

            return _db.Category.Include(c=>c.Products).Select(c => c);
        }

        public Category GetById(int id)
        {

            return _db.Category.FirstOrDefault(c => c.categoryId == id);
        }

        public void Insert(Category cat)
        {
            _db.Category.Add(cat);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Category cat)
        {
            _db.Category.Update(cat);
        }
    }
}
