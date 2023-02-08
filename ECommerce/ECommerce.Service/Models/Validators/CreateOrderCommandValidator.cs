using FluentValidation;
using ECommerce.Service.Models.Commands;

namespace ECommerce.Service.Models.Validators
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty();
            RuleFor(x => x.Address)
                .NotEmpty()
                .MaximumLength(50);
            RuleFor(x => x.PhoneNumber)
                .NotNull()
                .MaximumLength(20)
                .Matches("^[\\+\\d]\\d{3,19}$")
                .WithMessage("Phone number should be in format similar to: +38104.. and have a lenght of up to 20.");
        }
    }
}
