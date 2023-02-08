using ECommerce.Domain.Repository;
using ECommerce.Service.Models;
using ECommerce.Service.Models.Commands;
using ECommerce.Service.Models.Mappers;
using ECommerce.Service.Models.Queries;
using MediatR;

namespace ECommerce.Service.ShoppingCart
{
    public class ShoppingCartService :
        IRequestHandler<ShoppingCartContentQuery, ShoppingCartDto>,
        IRequestHandler<AddProductToCartCommand, int>,
        IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IProductRepository _productRepository;

        public ShoppingCartService(
            IShoppingCartRepository shoppingCartRepository,
            IProductRepository productRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _productRepository = productRepository;
        }

        public async Task<ShoppingCartDto> Handle(ShoppingCartContentQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return _shoppingCartRepository
                        .GetShoppingCart(request.CustomerId)
                        .MapToDto();
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Handle(AddProductToCartCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = _productRepository.GetProduct(request.ProductId);
                await _shoppingCartRepository.AddToCart(request.CustomerId, product, request.Quantity);
                return 1;
            }
            catch
            {
                throw;
            }
        }

        public Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
