using FluentValidation;
using StolenBlog.Models.DTOs;

namespace StolenBlog.API.Validators
{
	public class RegisterValidator : AbstractValidator<RegistrationRequestDto>
	{
		public RegisterValidator()
		{
			this.RuleFor(_ => _.Email)
				.NotNull()
				.WithMessage("Email is Required");

			this.RuleFor(_ => _.Password)
				.NotEmpty()
				.WithMessage("Password Cannot be left Blank")
				.MinimumLength(6)
				.WithMessage("Passwords Need to be at least 6 characters long");

			this.RuleFor(_ => _.RepeatPassword)
				.NotEmpty()
				.Equal(_ => _.Password)
				.WithMessage("Passwords do not match");

			this.RuleFor(_ => _.FirstName)
				.NotEmpty()
				.WithMessage("Name Cannot be left Empty");

			this.RuleFor(_ => _.Surname)
				.NotEmpty()
				.WithMessage("Surame Cannot be left Empty");

			this.RuleFor(_ => _.DateOfBirth)
				.LessThan(DateTime.Today.AddYears(-10))
				.WithMessage("You are Not old enough to use this application");

		}


	}
}
