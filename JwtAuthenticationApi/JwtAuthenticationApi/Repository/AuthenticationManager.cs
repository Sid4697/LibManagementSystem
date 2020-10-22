using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JwtAuthenticationApi.Models;

namespace JwtAuthenticationApi.Repository
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly Dictionary<string, string> users = new Dictionary<string, string>() {
            { "sid","abc@123"},
            {"abhi","mno@123" }
        };

        private readonly string tokenKey;
        public AuthenticationManager(string tokenKey)
        {
            this.tokenKey = tokenKey;
        }
        public string Authenticate(User user)
        {
            if (!users.Any(u => u.Key == user.UserName && u.Value == user.Password))
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(tokenKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
