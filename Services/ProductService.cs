using Multi_Tenant_Web.Models;
using Multi_Tenant_Web.Services.DTOs;

namespace Multi_Tenant_Web.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> GetProducts()
        {
            var products = _context.Products.ToList();
            return products;
        }
        public Product CreateProduct(CreateProductRequest request)
        {
            var product = new Product();
            product.Name = request.Name;
            product.Description = request.Description;

            _context.Products.Add(product);
            _context.SaveChanges();
            return product;

        }

        public bool DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        
    }
}
