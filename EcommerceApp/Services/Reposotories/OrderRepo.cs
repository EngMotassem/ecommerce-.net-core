using EcommerceApp.DatabaseContext;
using EcommerceApp.Models;
using EcommerceApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Services.Reposotories
{
    public class OrderRepo : IOrder
    {

        private readonly ApplicationDbContext _db;
        
        public OrderRepo(ApplicationDbContext db)
        {

            _db = db;

        }

        public int Count()
        {


            return _db.Order.Count();
            
        }

        public void Delete(int id)
        {

            var category = GetById(id);
                if(category!=null)
            {
                _db.Order.Remove(category);
            }
            
        }

        public IEnumerable<Order> GetAll()
        {

            return _db.Order.Select(c => c);
        }

        public Order GetById(int id)
        {

            return _db.Order.FirstOrDefault(c => c.OrderId == id);
        }

        public void Insert(Order cat)
        {
            _db.Order.Add(cat);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Order cat)
        {
            _db.Order.Update(cat);
        }
    }
}
