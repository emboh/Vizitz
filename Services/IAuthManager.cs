using System.Threading.Tasks;
using Vizitz.Entities;
using Vizitz.Models.Account;

namespace Vizitz.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginDTO loginDTO);

        Task<string> CreateToken();

        Task<User> GetUserDetail(string userName);
    }
}
