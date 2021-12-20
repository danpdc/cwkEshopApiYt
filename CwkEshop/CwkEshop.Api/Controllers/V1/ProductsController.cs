using CwkEshop.Api.Services;
using CwkEshop.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CwkEshop.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("/api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }
        
        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _productService.Products;

            return Ok(products);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _productService.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return BadRequest("Product not found");

            return Ok(product);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            _productService.Products.Add(product);

            return CreatedAtAction(nameof(GetProductById), new { id = product.Id}, product);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product updatedProduct)
        {
            var oldProduct = _productService.Products.FirstOrDefault( p => p.Id == id);

            if (oldProduct == null)
                return BadRequest("Product not found");

            oldProduct.Name = updatedProduct.Name;
            oldProduct.Price = updatedProduct.Price;
            oldProduct.AvailableQuantity = updatedProduct.AvailableQuantity;

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _productService.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return BadRequest("Product not found");

            _productService.Products.Remove(product);

            return NoContent();
        }
    }
}
