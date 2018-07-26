using EcommerceApp.DatabaseContext;
using EcommerceApp.Models;
using EcommerceApp.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Services.Reposotories
{
    public class CustomerRepo : ICustomer
    {

        private readonly ApplicationDbContext _db;        
      private readonly RoleManager<ApplicationRole> _roleManager;




        public CustomerRepo(ApplicationDbContext db, RoleManager<ApplicationRole> roleManager)
        {

            _db = db;
            _roleManager = roleManager;

        }

        public int Count()
        {

            return _db.Customer.Count();
            
        }

        public void Delete(string id)
        {

            var category = GetById(id);
                if(category!=null)
            {
                _db.Customer.Remove(category);
            }
            
        }

       
        public IEnumerable<Customer> GetAll()
        {

            return _db.Customer.Select(c => c);
        }

        public IEnumerable<ApplicationRole> GetAllRoles()
        {


            return _roleManager.Roles.ToList();
            //throw new NotImplementedException();
        }

        public Customer GetById(string id)
        {

            return _db.Customer.FirstOrDefault(c => c.Id == id);
        }

        public string getRoleName(string id)
        {
           var userId= _db.Customer.FirstOrDefault(c => c.Id == id);

            var userRoleid = _db.UserRoles.FirstOrDefault(a => a.RoleId == userId.Id);

           


            return _db.Roles.FirstOrDefault(r => r.Id == userRoleid.RoleId).Name;
        }

        public void Insert(Customer cat)
        {
            _db.Customer.Add(cat);
        }

        public async Task InsertRole(string pr)
        {
            
            var x = await _roleManager.RoleExistsAsync(pr);
            if (!x)
            {
                var role = new ApplicationRole();
                role.Name = pr;
                await _roleManager.CreateAsync(role);


            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Customer cat)
        {
            _db.Customer.Update(cat);
        }

        void ICustomer.InsertRole(string applicationRole)
        {
           // var x = _roleManager.RoleExistsAsync(applicationRole);
         //   if (x!=null)
           // {
                var role = new ApplicationRole();
            
                role.Name = applicationRole;
            role.NormalizedName = applicationRole;

                 _roleManager.CreateAsync(role);

                _db.Roles.Add(role);



           // }
        }
    }
}
