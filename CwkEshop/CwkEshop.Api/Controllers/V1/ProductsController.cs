using CwkEshop.Api.Services;
using CwkEshop.Dal;
using CwkEshop.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CwkEshop.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("/api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly DataContext _ctx;

        public ProductsController(DataContext ctx)
        {
            _ctx = ctx;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _ctx.Products.ToListAsync();

            return Ok(products);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _ctx.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
                return NotFound("Product not found");

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            _ctx.Products.Add(product);
            await _ctx.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProductById), new { id = product.Id}, product);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product updatedProduct)
        {
            var oldProduct = await _ctx.Products.FirstOrDefaultAsync( p => p.Id == id);

            if (oldProduct == null)
                return NotFound("Product not found");

            oldProduct.Name = updatedProduct.Name;
            oldProduct.Price = updatedProduct.Price;
            oldProduct.AvailableQuantity = updatedProduct.AvailableQuantity;

            _ctx.Products.Update(oldProduct);
            await _ctx.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _ctx.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
                return NotFound("Product not found");

            _ctx.Products.Remove(product);
            await _ctx.SaveChangesAsync();

            return NoContent();
        }
    }
}
