using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Models;
using Ecommerce.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ecommerce.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _service;
        public AccountController(IAccountService accountService)
        {
            _service = accountService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var response =  _service.GetUserDetails(loginModel.UserName, loginModel.Password).Result;
                if (response != null)
                {
                    var data = JsonConvert.DeserializeObject<RegisterModel>(response);
                    var userClaims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name,data.FirstName ),
                        new Claim(ClaimTypes.Email, data.Email),
                       
                    };
                    var grandmaIdentity = new ClaimsIdentity(userClaims, "User Identity");

                    var userPrincipal = new ClaimsPrincipal(new[] { grandmaIdentity });
                    HttpContext.SignInAsync(userPrincipal);

                    // if(!loginModel.RememberMe)
                    // {
                    //     //removing old session if available
                    //     if(!string.IsNullOrEmpty(HttpContext.Session.GetString("userDetails")))
                    //          HttpContext.Session.Remove("userDetails");
                    //     HttpContext.Session.SetString("userDetails",response);
                    // }
                    //else
                    // {
                    //     //Removing Existing cookies
                    //     if (!string.IsNullOrEmpty(Request.Cookies["userDetails"]))
                    //         Response.Cookies.Delete("userDetails");
                    //     Response.Cookies.Append("userDetails", response);
                    // }
                    return RedirectToAction("Index", "Dashboard");
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                var response =await _service.CreateNewUser(registerModel);
                if (response != null)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
    }
}
