using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserAccountApi.Data.Interface;
using UserAccountApi.Data.Repository;
using UserAccountApi.Model;

namespace UserAccountApi.Controllers
{
  //  [Authorize]
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
            var response = _rep.GetUserDetails(UserName, Password);
            return Ok(response.Result);
        }
        [HttpPost]
        [Route("CreatUser/")]
        public async Task<IActionResult> CreateNewUser(UserDetail userDetails)
        {
            try
            {
                if (userDetails == null)
                    return BadRequest();
                var response = _rep.CreateNewUser(userDetails);
                return Created("", response.Result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  "Error creating new User");
            }

        }

    }
}
