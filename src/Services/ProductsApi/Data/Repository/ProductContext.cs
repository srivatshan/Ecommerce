using Microsoft.EntityFrameworkCore;
using ProductsApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsApi.Data.Repository
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions options) : base(options)
        {
        }
       public DbSet<ProductDetails> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductDetails>().HasData(
                new ProductDetails
                {
                    Id = 1,
                    Name = "Samsung_01",
                    Description = "Mobile Phone",
                    Price = 10,
                    PictureName = "Samsung_01",
                    PictureUrl = "Url"
                },
                new ProductDetails
                {
                    Id = 2,
                    Name = "Samsung_02",
                    Description = "Mobile Phone",
                    Price = 11,
                    PictureName = "Samsung_02",
                    PictureUrl = "Url"
                });
        }

    }
}
