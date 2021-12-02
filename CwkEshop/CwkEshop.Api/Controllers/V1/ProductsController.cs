using CwkEshop.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CwkEshop.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("/api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Visual Studio", Price = 48, AvailableQuantity = 99}
            };

            return Ok(products);
        }
    }
}
