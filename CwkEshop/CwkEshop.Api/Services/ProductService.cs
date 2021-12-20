using CwkEshop.Domain.Models;

namespace CwkEshop.Api.Services
{
    public class ProductService
    {
        public ProductService()
        {
            Products = new List<Product>
            {
                new Product {Id = 1, Name = "Visual Studio 2022", Price = 45.78, AvailableQuantity = 10}
            };
        }
        public List<Product> Products { get; set; }
    }
}
