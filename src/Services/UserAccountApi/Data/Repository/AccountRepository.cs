﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAccountApi.Data.Interface;
using UserAccountApi.Model;

namespace UserAccountApi.Data.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserAccountContext _db;
        public AccountRepository(UserAccountContext userAccountContext)
        {
            _db = userAccountContext;
        }

        public async Task<UserDetail> CreateNewUser(UserDetail userDetail)
        {
            _db.UserDetails.Add(userDetail);
            _db.SaveChanges();
            return userDetail;
        }

        public async Task<UserDetail> GetUserDetails(string UserName, string Password)
        {
            var response = _db.UserDetails.FirstOrDefault(x => x.Email == UserName && x.Password == Password);
            return response;
        }
    }
}
