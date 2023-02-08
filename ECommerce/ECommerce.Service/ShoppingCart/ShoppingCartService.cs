using ECommerce.Service.Models;
using ECommerce.Domain.Repository;
using ECommerce.Service.Models.Commands;
using ECommerce.Service.Models.Mappers;
using ECommerce.Service.Models.Queries;
using ECommerce.Service.Services.PriceCalculation;
using MediatR;

namespace ECommerce.Service.ShoppingCart
{
    public class ShoppingCartService :
        IRequestHandler<ShoppingCartContentQuery, ShoppingCartDto>,
        IRequestHandler<AddProductToCartCommand, int>,
        IRequestHandler<CreateOrderCommand, OrderDto>
    {
        private readonly IPriceCalculationService _priceCalculationService;
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IMediator _mediator;

        public ShoppingCartService(
            IPriceCalculationService priceCalculationService,
            IShoppingCartRepository shoppingCartRepository,
            ICustomerRepository customerRepository,
            IProductRepository productRepository,
            IOrderRepository orderRepository,
            IMediator mediator)
        {
            _priceCalculationService = priceCalculationService;
            _shoppingCartRepository = shoppingCartRepository;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _mediator = mediator;
        }

        public async Task<ShoppingCartDto> Handle(ShoppingCartContentQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = _customerRepository.GetCustomer(request.CustomerId);
                return _shoppingCartRepository
                        .GetShoppingCart(customer)
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
                var customer = _customerRepository.GetCustomer(request.CustomerId);
                var product = _productRepository.GetProduct(request.ProductId);

                if (product.Quantity < request.Quantity)
                {
                    var supplierStockQuantity = await _mediator.Send(new SupplierStockQuery { ProductId = request.ProductId });

                    if (product.Quantity + supplierStockQuantity < request.Quantity)
                        throw new Exception("Not enough quantity in stock.");
                }

                await _shoppingCartRepository.AddToCart(customer, product, request.Quantity);
                await _productRepository.AdjustProductQuantity(request.ProductId, request.Quantity);

                return 1;
            }
            catch
            {
                throw;
            }
        }

        public async Task<OrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = _customerRepository.GetCustomer(request.CustomerId);

                if (!customer.Cart.Any())
                {
                    throw new Exception("Customer cart is empty!");
                }

                var calculatedPricesModel = _priceCalculationService.CalculateOrderTotalPrice(customer.Cart, request.PhoneNumber);

                var createdOrder = _orderRepository.CreateOrder(customer, calculatedPricesModel.OrderTotal, calculatedPricesModel.DiscountTotal, request.Address);

                await _shoppingCartRepository.EmptyShoppingCart(customer);

                return createdOrder.MapToDto();
            }
            catch
            {
                throw;
            }
        }
    }
}
