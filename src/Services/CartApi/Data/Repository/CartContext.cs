using CartApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartApi.Data.Repository
{
    public class CartContext : DbContext
    {
        public CartContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<CartDetails> Products { get; set; }
    }
}
