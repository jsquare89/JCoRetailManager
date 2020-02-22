using JRMDataManager.Library.Models;
using System.Collections.Generic;

namespace JRMDataManager.Library.DataAccess
{
    public interface IUserData
    {
        List<UserModel> GetUserById(string Id);
    }
}