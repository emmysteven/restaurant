using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Restaurant.Application.Common.Interfaces;

namespace Restaurant.Application.UseCases.Shops.Commands.CreateShop
{
    public class CreateShopValidator : AbstractValidator<CreateShopCommand>
    {
        private readonly IShopRepository _shopRepository;

        public CreateShopValidator(IShopRepository shopRepository)
        {
            _shopRepository = shopRepository;

            RuleFor(t => t.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("{PropertyName} can not be empty")
                .NotNull()
                .Length(3, 50).WithMessage("{PropertyName} must be between 4 to 50 characters");

            RuleFor(t => t.Website)
                .Cascade(CascadeMode.Stop)
                .MustAsync(IsUniqueWebsite).WithMessage("This {PropertyName} already exists.");

            RuleFor(t => t.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("{PropertyName} can not be empty")
                .NotNull()
                .EmailAddress().WithMessage("Enter a valid {PropertyName}")
                .MustAsync(IsUniqueEmail).WithMessage("This {PropertyName} already exists.");

            RuleFor(t => t.PhoneNumber)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("{PropertyName} can not be empty")
                .NotNull()
                .Matches("^\\d{11}$").WithMessage("{PropertyName} must be 11 digits")
                .MustAsync(IsUniquePhoneNumber).WithMessage("This {PropertyName} already exists.");

            RuleFor(t => t.State)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("{PropertyName} can not be empty")
                .NotNull();
                // .Matches("^\\d{10}$").WithMessage("{PropertyName} must be 10 digits")

                RuleFor(t => t.LocalGovernmentArea)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("{PropertyName} can not be empty")
                .NotNull();

            RuleFor(t => t.Address)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("{PropertyName} can not be empty")
                .NotNull();
            
            RuleFor(t => t.ImageFile.Length).ExclusiveBetween(0, 2000000)
                .WithMessage($"File length should be greater than 0 and less than {2000000 / 1024 / 1024} MB")
                .When(t => t.ImageFile != null);
        }

        private async Task<bool> IsUniqueEmail(string email, CancellationToken cancellationToken)
        {
            return await _shopRepository.IsUniqueEmailAsync(email);
        }

        private async Task<bool> IsUniqueWebsite(string website, CancellationToken cancellationToken)
        {
            return await _shopRepository.IsUniqueWebsiteAsync(website);
        }

        private async Task<bool> IsUniquePhoneNumber(string phoneNumber, CancellationToken cancellationToken)
        {
            return await _shopRepository.IsUniquePhoneNumberAsync(phoneNumber);
        }
    }
}