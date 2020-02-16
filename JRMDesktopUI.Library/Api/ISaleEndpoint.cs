using JRMDesktopUI.Library.Models;
using System.Threading.Tasks;

namespace JRMDesktopUI.Library.Api
{
    public interface ISaleEndpoint
    {
        Task PostSale(SaleModel sale);
    }
}