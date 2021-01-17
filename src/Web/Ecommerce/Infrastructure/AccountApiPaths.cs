using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure
{
    public static class AccountApiPaths
    {
        public static string GetUserDetails(string baseUri,string UserName, string Password)
        {
            return $"{baseUri}GetUserDetails/{UserName}/{Password}";
        }
    }
}
