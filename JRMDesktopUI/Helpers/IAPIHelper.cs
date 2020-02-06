using JRMDesktopUI.Models;
using System.Threading.Tasks;

namespace JRMDesktopUI.Helpers
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
    }
}