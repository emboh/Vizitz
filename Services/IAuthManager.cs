using System.Threading.Tasks;
using Vizitz.Models.Account;

namespace Vizitz.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginDTO loginDTO);

        Task<string> CreateToken();
    }
}
