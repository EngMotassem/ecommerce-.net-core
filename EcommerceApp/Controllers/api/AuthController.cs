using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EcommerceApp.Models;
using EcommerceApp.Services.DTO;
using EcommerceApp.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EcommerceApp.Controllers.api
{
    [Produces("application/json")]
    [Route("api/Auth")]
    public class AuthController : Controller
    {

        private readonly IAuth _autho;

        private readonly IConfiguration _config;


        public AuthController(IAuth auth, IConfiguration config)
        {

            _autho = auth;

            _config = config;

        }
        // GET: api/Auth
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Auth/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Auth
        [HttpPost ("register")]
        public async Task<IActionResult> Register([FromBody] UserDToForRegisteration userDToForRegisteration)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

             userDToForRegisteration.UserName = userDToForRegisteration.UserName.ToLower();

            if (await _autho.IsUserExistAsync(userDToForRegisteration.UserName))
                return BadRequest("user alraedy exist");

            var UserTocreate = new User
            {
                UserName = userDToForRegisteration.UserName
            };

            var CreateUser = _autho.Register(UserTocreate, userDToForRegisteration.PassWord);

            return StatusCode(201);



        }



        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDToForLogin userForLoginDto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userFromRepo = await _autho.Login(userForLoginDto.UserName.ToLower(), userForLoginDto.PassWord);

            if (userFromRepo == null)
                return Unauthorized();

            // generate token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.GetSection("AppSettings:token").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                    new Claim(ClaimTypes.Name, userFromRepo.UserName)
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new { tokenString });



        }

        // PUT: api/Auth/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
