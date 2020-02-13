using JRMDesktopUI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JRMDesktopUI.Library.Api
{
    public interface IProductEndpoint
    {
        Task<List<ProductModel>> GetAll();
    }
}