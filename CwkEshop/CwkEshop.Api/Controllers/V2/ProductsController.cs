using CwkEshop.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CwkEshop.Api.Controllers.V2
{
    [ApiVersion("2.0")]
    [Route("/api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Rider", Price = 48, AvailableQuantity = 99}
            };

            return Ok(products);
        }
    }
}
