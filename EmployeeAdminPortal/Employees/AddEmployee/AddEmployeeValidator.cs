using FluentValidation;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EmployeeAdminPortal.Employees.AddEmployee
{
    public class AddEmployeeValidator : AbstractValidator<AddEmployeeRequest>
    {
        public AddEmployeeValidator()
        {
            RuleFor(x => x.Employee.Name)
                .NotEmpty()
                .WithMessage("'{PropertyName}' cannot be empty.")
                .MaximumLength(100)
                .WithMessage("The length of '{PropertyName}' must be {MaxLength} characters or fewer.")
                .Matches(@"^\D*$")
                .WithMessage("'{PropertyName}' must not contain numbers.");

            RuleFor(x => x.Employee.Phone)
                .Matches(@"^\+380\d{9}$")
                .WithMessage("Invalid format for '{PropertyName}'. Expected format is +380XXXXXXXXX.")
                .When(x => !string.IsNullOrEmpty(x.Employee.Phone));
        }
    }
}
