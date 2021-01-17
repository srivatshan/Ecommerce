using ProductsApi.Data.Interface;
using ProductsApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsApi.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _productContext;
        public ProductRepository(ProductContext productContext)
        {
            _productContext = productContext;
        }
        public void AddProduct(ProductDetails productDetails)
        {
            _productContext.Products.Add(productDetails);
            _productContext.SaveChanges();
        }

        public void DeleteProduct(ProductDetails productDetails)
        {
            _productContext.Products.Remove(productDetails);
            _productContext.SaveChanges();
        }

        public async Task<IEnumerable<ProductDetails>> GetAllProduct()
        {
            return  _productContext.Products.ToList();
        }

        public async Task<ProductDetails> GetProduct(int ProductId)
        {
            return _productContext.Products.FirstOrDefault(x => x.Id == ProductId);
        }

        public void UpdateProduct(ProductDetails productDetails)
        {
            var details = _productContext.Products.Find(productDetails.Id);
            if (details != null)
            {
                details.Name = productDetails.Name;
                details.Description = productDetails.Description;
                details.Price = productDetails.Price;
                details.PictureUrl = productDetails.PictureUrl;
                details.PictureName = productDetails.PictureName;
                _productContext.SaveChanges();
            }
        }
    }
}
