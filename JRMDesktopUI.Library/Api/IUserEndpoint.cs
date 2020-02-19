using JRMDesktopUI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JRMDesktopUI.Library.Api
{
    public interface IUserEndpoint
    {
        Task<List<UserModel>> GetAll();
    }
}