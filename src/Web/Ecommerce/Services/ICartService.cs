using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Services
{
    public interface ICartService
    {
        List<ProductDetails> getCartItems(int userid);
        int AddItemToCart(ProductDetails productDetails);
    }
}
