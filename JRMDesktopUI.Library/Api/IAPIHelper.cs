using JRMDesktopUI.Models;
using System.Threading.Tasks;

namespace JRMDesktopUI.Library.Api
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
        Task GetLoggedInUserInfo(string token);
    }
}