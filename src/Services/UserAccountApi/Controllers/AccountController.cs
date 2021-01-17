using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserAccountApi.Data.Interface;
using UserAccountApi.Data.Repository;

namespace UserAccountApi.Controllers
{
    [Authorize]
    [Route("api/Account")]
    [ApiController]
    public class AccountController : ControllerBase 
    {
        private readonly IAccountRepository _rep;
        public AccountController(IAccountRepository accountRepository)
        {
            _rep = accountRepository;
        }
        [HttpGet]
        [Route("GetUserDetails/{UserName}/{Password}")]
        public async Task<IActionResult> GetUserDetails(string UserName, string Password)
        {
          var response=   _rep.GetUserDetails(UserName, Password);
            return Ok(response);
        }

    }
}
