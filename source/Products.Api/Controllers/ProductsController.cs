using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Products.Domain.Products.Commands;
using Products.Domain.Products.Handlers;
using Products.Domain.Products.Models;
using Products.Domain.Products.Repositories;

namespace Products.Api.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ProductCommandsHandler _productCommandsHandler;

        public ProductsController(IProductRepository productRepository, ProductCommandsHandler productCommandsHandler)
        {
            _productRepository = productRepository;
            _productCommandsHandler = productCommandsHandler;
        }

        [HttpGet]
        public async Task<IActionResult> FindProducts([FromQuery]ProductParameters parameters)
        {
            return Ok(await _productRepository.FindProducts(parameters));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProduct command)
        {
            var product = await _productCommandsHandler.Handle(command);

            var productDetails = new ProductDetails
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.CategoryId,
            };

            return Created(string.Empty, productDetails);
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

        [HttpPut("{productId}")]
        public async Task<IActionResult> CreateProduct(Guid productId, UpdateProduct command)
        {
            command.Id = productId;

            await _productCommandsHandler.Handle(command);

            return NoContent();
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> CreateProduct(Guid productId)
        {
            await _productCommandsHandler.Handle(new RemoveProduct { Id = productId });

            return NoContent();
        }
    }
}
