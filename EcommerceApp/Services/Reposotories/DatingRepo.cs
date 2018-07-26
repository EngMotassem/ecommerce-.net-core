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
    public class DatingRepo : IDating
    {

        private readonly ApplicationDbContext _context;

        public DatingRepo(ApplicationDbContext context)
        {
            _context = context;
                
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Photo> GetMainPhotoForUserAsync(int userId)
        {
            return await _context.Photos.Where(u => u.UserId == userId).FirstOrDefaultAsync(p => p.IsMain);
        }

        public Task<Photo> GetPhoto(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.JwtUsers.Include(p => p.Photos).FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public async  Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.JwtUsers.Where(c=>c.Country != null).Include(p => p.Photos).ToListAsync();

            return users;

        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
