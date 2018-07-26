using EcommerceApp.DatabaseContext;
using EcommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Services.Interfaces
{
    public interface ICustomer
    {

        IEnumerable<Customer> GetAll();


        Customer GetById(string id);

        IEnumerable<ApplicationRole> GetAllRoles();

        void  InsertRole(string applicationRole);

        void Insert(Customer cat);
        void Update(Customer cat);

        void Delete(string id);
         
        int Count();

        void Save();


        string getRoleName(string id);







    }
}
