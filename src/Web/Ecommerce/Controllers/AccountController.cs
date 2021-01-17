using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Models;
using Ecommerce.Services;
using Microsoft.AspNetCore.Mvc;

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
            if(ModelState.IsValid)
            {
             var response= await _service.GetUserDetails(loginModel.UserName, loginModel.Password);
                if(response != null)
                {
                    if(!loginModel.RememberMe)
                    {
                        HttpContext.Session.Set("userDetails", Encoding.ASCII.GetBytes(response));
                    }
                   else
                    {
                        Response.Cookies.Append("userDetails", response);
                    }
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
        public IActionResult Register(RegisterModel registerModel)
        {
            return View();
        }
    }
}
