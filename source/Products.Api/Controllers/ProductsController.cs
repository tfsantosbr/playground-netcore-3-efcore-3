using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Products.Domain.Products.Models;
using Products.Domain.Products.Repositories;

namespace Products.Api.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> FindProducts(ProductParameters parameters)
        {
            return Ok(await _productRepository.FindProducts(parameters));
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProduct(Guid productId)
        {
            var product = await _productRepository.GetProduct(productId);

            if (product == null)
            {
                return NotFound();
            }

            var productDetails = new ProductDetails
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.CategoryId,
            };

            return Ok(productDetails);
        }
    }
}
