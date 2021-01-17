using ProductsApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsApi.Data.Interface
{
   public interface IProductRepository
    {
        Task<IEnumerable<ProductDetails>> GetAllProduct();

        Task<ProductDetails> GetProduct(int ProductId);

        void AddProduct(ProductDetails productDetails);

        void UpdateProduct(ProductDetails productDetails);

        void DeleteProduct(ProductDetails productDetails);


    }
}
