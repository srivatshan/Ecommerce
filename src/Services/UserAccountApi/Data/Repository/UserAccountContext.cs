using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAccountApi.Model;

namespace UserAccountApi.Data.Repository
{
    public class UserAccountContext : DbContext
    {
        public UserAccountContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<UserDetail> UserDetails { get; set; }
   
    }
}
