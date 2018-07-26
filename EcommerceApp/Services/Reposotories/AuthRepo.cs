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
    public class AuthRepo : IAuth
    {

        private readonly ApplicationDbContext _db;
        
        public AuthRepo(ApplicationDbContext db)
        {

            _db = db;

        }

        public async Task<bool> IsUserExistAsync(string username)
        {
            if (await _db.JwtUsers.AnyAsync(x => x.UserName == username))
                return true;

            return false;
        }

        public async Task<User> Login(string username, string password)
        {
            var user = await _db.JwtUsers.FirstOrDefaultAsync(x => x.UserName == username);

            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

       

        public async Task<User> Register(User user, string password)
        {

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _db.JwtUsers.AddAsync(user);

            await _db.SaveChangesAsync();

            return user;

        }







        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }




        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }


    }
}
