using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using JwtAuthenticationApi.Models;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuthenticationApi.Repository
{
    public interface IAuthenticationManager
    {
        public string Authenticate(User user);
    }
}
