﻿using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace RentAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IConfiguration _config;

        public AuthController(IConfiguration configuration)
        {
            _config = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Auth()//([FromBody] UserModel login)
        {
            IActionResult response = Unauthorized();
            //var user = AuthenticateUser(login);

            //if (user != null)
            //{
                var tokenString = GenerateJSONWebToken("carlos");
                response = Ok(new { token = tokenString });
            //}

            return response;
        }

        private string GenerateJSONWebToken(string userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));    
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);    
    
            var claims = new[]
            {    
                new Claim(JwtRegisteredClaimNames.Sub, "Username"),    
                new Claim(JwtRegisteredClaimNames.Email, "EmailAddress"),    
                new Claim("DateOfJoing", "DateOfJoing.ToString('yyyy-MM-dd')"),    
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())    
            };    
    
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],    
            _config["Jwt:Issuer"],    
            claims,    
            expires: DateTime.Now.AddMinutes(120),    
            signingCredentials: credentials);    
    
            return new JwtSecurityTokenHandler().WriteToken(token);  
        }

        //private UserModel AuthenticateUser(UserModel login)
        //{
        //    UserModel user = null;

        //    //Validate the User Credentials    
        //    //Demo Purpose, I have Passed HardCoded User Information    
        //    if (login.Username == "Jignesh")
        //    {
        //        user = new UserModel { Username = "Jignesh Trivedi", EmailAddress = "test.btest@gmail.com" };
        //    }
        //    return user;
        //}
    }
}