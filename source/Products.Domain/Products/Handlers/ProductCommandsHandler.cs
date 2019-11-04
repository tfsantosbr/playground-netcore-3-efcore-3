using System.Threading.Tasks;
using Products.Domain.Core.Persistence;
using Products.Domain.Products.Commands;
using Products.Domain.Products.Repositories;

namespace Products.Domain.Products.Handlers
{
    public class ProductCommandsHandler
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductCommandsHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Product> Handle(CreateProduct command)
        {
            var product = new Product(
                title: command.Title,
                description: command.Description,
                price: command.Price,
                categoryId: command.CategoryId
                );

            await _productRepository.AddProduct(product);

            await _unitOfWork.Commit();

            return product;
        }

        public async Task Handle(UpdateProduct command)
        {
            var product = await _productRepository.GetProduct(command.Id);

            product.Update(
                title: command.Title,
                description: command.Description,
                price: command.Price,
                categoryId: command.CategoryId
            );

            _productRepository.UpdateProduct(product);

            await _unitOfWork.Commit();
        }

        public async Task Handle(RemoveProduct command)
        {
            var product = await _productRepository.GetProduct(command.Id);

            _productRepository.RemoveProduct(product);

            await _unitOfWork.Commit();
        }
    }
}