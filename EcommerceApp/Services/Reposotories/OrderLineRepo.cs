using EcommerceApp.DatabaseContext;
using EcommerceApp.Models;
using EcommerceApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Services.Reposotories
{
    public class OrderLineRepo : IOrderLine
    {

        private readonly ApplicationDbContext _db;
        
        public OrderLineRepo(ApplicationDbContext db)
        {

            _db = db;

        }

        public int Count()
        {


            return _db.OrderLine.Count();
            
        }

        public void Delete(int id)
        {

            var category = GetById(id);
                if(category!=null)
            {
                _db.OrderLine.Remove(category);
            }
            
        }

        public IEnumerable<OrderLine> GetAll()
        {

            return _db.OrderLine.Select(c => c);
        }

        public OrderLine GetById(int id)
        {

            return _db.OrderLine.FirstOrDefault(c => c.OrderLineId == id);
        }

        public void Insert(OrderLine cat)
        {
            _db.OrderLine.Add(cat);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(OrderLine cat)
        {
            _db.OrderLine.Update(cat);
        }
    }
}
