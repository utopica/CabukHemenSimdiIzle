using CabukHemenSimdiIzle.MVC.ViewModels;
using FluentValidation;

namespace CabukHemenSimdiIzle.MVC.Validators
{
    public class AuthLoginValidator:AbstractValidator<AuthLoginVM>
    {
        public AuthLoginValidator()
        {
            RuleFor(s => s.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(s => s.Password)
               .NotEmpty().WithMessage("Password is required.");
            
        }
    }
}
