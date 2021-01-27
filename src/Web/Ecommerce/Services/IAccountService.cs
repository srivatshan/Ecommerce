using Ecommerce.Models;
using System.Threading.Tasks;

namespace Ecommerce.Services
{
    public interface IAccountService
    {
        Task<string> GetUserDetails(string UserName, string Password);
        Task<RegisterModel> CreateNewUser(RegisterModel registerModel);
    }
}
