using Ecommerce.Infrastructure;
using Ecommerce.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Services
{
    public class AccountService : IAccountService
    {
        private readonly IOptionsSnapshot<AppSettings> _settings;
        private readonly IHttpClient _apiClient;
        private readonly ILogger<AccountService> _logger;
        private readonly string _remoteServiceBaseUrl;
        public AccountService(IOptionsSnapshot<AppSettings> settings, IHttpClient httpClient, ILogger<AccountService> logger)
        {
            _settings = settings;
            _apiClient = httpClient;
            _logger = logger;
            _remoteServiceBaseUrl = $"{_settings.Value.AccountUrl}api/Account/";
        }
        public async Task<string> GetUserDetails(string UserName, string Password)
        {
            var AccountDetail = AccountApiPaths.GetUserDetails(_remoteServiceBaseUrl, UserName, Password);
            return await _apiClient.GetStringAsync(AccountDetail);
          //  return JsonConvert.DeserializeObject<RegisterModel>(response.ToString());
        }


    }
}
