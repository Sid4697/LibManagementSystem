using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
          
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
           
            string token = "";
            using (var httpclient = new HttpClient())
            {
                httpclient.BaseAddress = new Uri("http://localhost:51384/");
                var postData = await httpclient.PostAsJsonAsync<User>("api/Authentication/AuthenicateUser",user);
              //  var res = postData.Result;
                if (postData.IsSuccessStatusCode)
                {
                    token = await postData.Content.ReadAsStringAsync();
                    TempData["token"] = token;
                    if (token != null)
                    {
                        return RedirectToAction("Index", "dashboardPage");
                    }

                }
            }
            return View("Login");
        }
    }
}
