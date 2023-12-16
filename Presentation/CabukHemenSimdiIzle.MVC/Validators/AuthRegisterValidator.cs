using CabukHemenSimdiIzle.MVC.ViewModels;
using FluentValidation;

namespace CabukHemenSimdiIzle.MVC.Validators
{
    public class AuthRegisterValidator:AbstractValidator<AuthRegisterVM>
    {
        public AuthRegisterValidator()
        {
            RuleFor(s => s.Email)
           .NotEmpty().WithMessage("Email is required.")
           .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(s => s.UserName)
                .NotEmpty().WithMessage("Username is required.")
                .MinimumLength(2).WithMessage("Username must be at least 2 characters.")
                .MaximumLength(15).WithMessage("Username must be at most 15 characters.");

            RuleFor(s => s.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters.")
                .MaximumLength(20).WithMessage("Password must be at most 20 characters.");

            RuleFor(s => s.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(15).WithMessage("Username must be at most 15 characters.");

            RuleFor(s => s.SurName)
                .NotEmpty().WithMessage("Surname is required.")
                 .MaximumLength(15).WithMessage("Username must be at most 15 characters.");
           (RuleFor(s => s.BirthDate))
                .NotEmpty().WithMessage("Birthdate is required.");

            RuleFor(s => s.Gender)
                .IsInEnum().WithMessage("Invalid gender value.");
        }
    }
}
