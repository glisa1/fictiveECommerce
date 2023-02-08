using FluentValidation;
using ECommerce.Service.Models.Commands;

namespace ECommerce.Service.Models.Validators
{
    public class AddProductToCartCommandValidator : AbstractValidator<AddProductToCartCommand>
    {
        public AddProductToCartCommandValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty();
            RuleFor(x => x.CustomerId).NotEmpty();
            RuleFor(x => x.Quantity)
                .NotEmpty()
                .LessThanOrEqualTo(50);
        }
    }
}
