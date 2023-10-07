using Multi_Tenant_Web.Models;
using Multi_Tenant_Web.Services.DTOs;

namespace Multi_Tenant_Web.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        Product CreateProduct(CreateProductRequest request);
        bool DeleteProduct(int id);
    }
}
