using ECommerce.Domain.Models.Domain;

namespace ECommerce.Service.Models.Mappers
{
    public static class OrderToDtoMapper
    {
        public static OrderDto MapToDto(this Order model)
        {
            return new OrderDto
            {
                OrderId = model.Id,
                OrderTotal = model.TotalAmount,
                AppliedDiscount = model.AppliedDiscount
            };
        }
    }
}
