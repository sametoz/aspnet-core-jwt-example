using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using jwt_example.Models;

namespace jwt_example.Controllers
{
    public class TokenController : ControllerBase
    {
        [HttpPost("new")]
        public IActionResult GetToken([FromBody]User user)
        {
            Console.WriteLine("Username: " + user.Username);
            Console.WriteLine("Password: " + user.Password);

            if (IsValidUser(user.Username, user.Password))
            {
                return new ObjectResult(GenerateToken(user.Username));
            }
            else return Unauthorized();

        }

        private string GenerateToken(string userName)
        {
            var claims = new Claim[]{
                new Claim(JwtRegisteredClaimNames.UniqueName,userName),
                new Claim(JwtRegisteredClaimNames.Email,"samet.oz17@gmail.com"),
                new Claim(JwtRegisteredClaimNames.NameId,Guid.NewGuid().ToString())
            };

            SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("samet öz"));
            var token = new JwtSecurityToken(
                issuer: "issuer.samet.com",
                audience: "audience.samet.com",
                claims: claims,
                expires: DateTime.Now.AddMinutes(2),
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private bool IsValidUser(string userName, string password)
        {
            //TODO: implement identity
            return true;
        }

    }
}