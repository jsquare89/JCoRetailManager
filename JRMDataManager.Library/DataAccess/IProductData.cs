using JRMDataManager.Library.Models;
using System.Collections.Generic;

namespace JRMDataManager.Library.DataAccess
{
    public interface IProductData
    {
        ProductModel GetProductById(int productId);
        List<ProductModel> GetProducts();
    }
}