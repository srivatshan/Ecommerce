using Ecommerce.Infrastructure;
using Ecommerce.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel.Client;
using System.Net.Http;

namespace Ecommerce.Services
{
    public class ProductService : IProductService
    {
        private readonly IOptionsSnapshot<AppSettings> _settings;
        private readonly IHttpClient _apiClient;
        private readonly ILogger<ProductService> _logger;
        private readonly string _remoteServiceBaseUrl;
        public ProductService(IOptionsSnapshot<AppSettings> settings, IHttpClient httpClient, ILogger<ProductService> logger)
        {
            _settings = settings;
            _apiClient = httpClient;
            _logger = logger;
            _remoteServiceBaseUrl = $"{_settings.Value.ProductsUrl}api/Products/";
        }

        public async Task<IEnumerable<ProductDetails>> GetCatalogItems()
        {
            var productsUri = ApiPaths.Catalog.GetAllProductItems(_remoteServiceBaseUrl);
            IEnumerable<ProductDetails> result = null;
            var response = await _apiClient.GetStringAsync(productsUri);
            result = JsonConvert.DeserializeObject<IEnumerable<ProductDetails>>(response.ToString());
            return result;
        }






    }
}
