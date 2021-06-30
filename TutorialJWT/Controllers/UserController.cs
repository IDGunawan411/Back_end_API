using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TutorialJWT.Model;
using TutorialJWT.Models;

namespace TutorialJWT.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IConfiguration _config;

        public UserController(IConfiguration config)
        {
            _config = config;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserModel login)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        private string GenerateJSONWebToken(UserModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddHours(1),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserModel AuthenticateUser(UserModel login)
        {
            UserModel user = null;

            //Validate the User Credentials    
            //Demo Purpose, I have Passed HardCoded User Information    
            db_latihan_gunawanContext db = new db_latihan_gunawanContext();
            var userDbCek = db.Users.Where(u => u.Username == login.Username && u.Password == login.Password).FirstOrDefault();
            if (userDbCek != null)
            {
                user = login;
            }
            return user;
        }
        //================================================
        [HttpGet]
        public JsonResult GetUser()
        {
            db_latihan_gunawanContext db = new db_latihan_gunawanContext();
            var data = db.Users.ToList();
            return new JsonResult(data);
        }

        [HttpPost]
        public JsonResult Create(User user)
        {
            db_latihan_gunawanContext db = new db_latihan_gunawanContext();

            db.Users.Add(user);
            db.SaveChanges();
            return new JsonResult("Add sukses");
        }

        [HttpPatch]
        public JsonResult Update(User user)
        {
            db_latihan_gunawanContext db = new db_latihan_gunawanContext();
            db.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();

            return new JsonResult("Berhasil update");
        }

        [HttpDelete]
        public JsonResult Delete(string username)
        {
            db_latihan_gunawanContext db = new db_latihan_gunawanContext();
            db.Remove(db.Users.Where(e => e.Username == username).FirstOrDefault());
            db.SaveChanges();
            return new JsonResult("Berhasil delete");
        }
    }
}
