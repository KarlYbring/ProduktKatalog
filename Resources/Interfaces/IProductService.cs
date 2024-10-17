using Resources.Enums;
using Resources.Models;

namespace Resources.Interfaces
{
    public interface IProductService
    {
        ResultStatus AddProduct(Product product);
        ResultStatus DeleteProduct(Product product);
        IEnumerable<Product> GetAllProducts();
    }
}
