using EcommerceApp.DatabaseContext;
using EcommerceApp.Models;
using EcommerceApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Services.Reposotories
{
    public class CartItemRepo : ICartItem
    {

        private readonly ApplicationDbContext _db;
        
        public CartItemRepo(ApplicationDbContext db)
        {

            _db = db;

        }

        public int Count()
        {


            return _db.CartItem.Count();
            
        }

        public void Delete(int id)
        {

            var category = GetById(id);
                if(category!=null)
            {
                _db.CartItem.Remove(category);
            }
            
        }

        public IEnumerable<CartItem> GetAll()
        {

            return _db.CartItem.Select(c => c);
        }

        public CartItem GetById(int id)
        {

            return _db.CartItem.FirstOrDefault(c => c.CartId == id);
        }

        public void Insert(CartItem cat)
        {
            _db.CartItem.Add(cat);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(CartItem cat)
        {
            _db.CartItem.Update(cat);
        }
    }
}
