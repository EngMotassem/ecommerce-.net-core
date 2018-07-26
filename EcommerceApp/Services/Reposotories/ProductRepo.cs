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
    public class ProductRepo : IProduct
    {

        private readonly ApplicationDbContext _db;

        public ProductRepo(ApplicationDbContext db)
        {
            _db = db;

        }
        public int Count()
        {

            return _db.Product.Count();
      }

        public void Delete(int id)
        {

            var product = GetById(id);
            if (product != null)
            {
                _db.Product.Remove(product);
            }
        }

        public IEnumerable<Product> GetAll()
        {
            var prod= _db.Product.Include(s => s.Category).Select(p => p);


            return prod; 
                
                
                }

        public Product GetById(int id)
        {
            return _db.Product.FirstOrDefault(s => s.ProductId == id);
        }

        public void Insert(Product cat)
        {
            _db.Product.Add(cat);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Product cat)
        {
            _db.Product.Update(cat);
        }
    }
}
