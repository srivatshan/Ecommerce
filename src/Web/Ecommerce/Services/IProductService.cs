using Ecommerce.Infrastructure;
using Ecommerce.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Services
{

    public interface IProductService
    {
        Task<IEnumerable<ProductDetails>> GetCatalogItems();

    }
}
