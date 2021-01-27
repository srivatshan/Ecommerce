using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAccountApi.Model;

namespace UserAccountApi.Data.Interface
{
   public interface IAccountRepository
    {
        Task<UserDetail> GetUserDetails(string UserName, string Password);
        Task<UserDetail> CreateNewUser(UserDetail userDetail);
    }
}
