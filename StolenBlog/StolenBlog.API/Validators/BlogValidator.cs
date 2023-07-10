using FluentValidation;
using StolenBlog.Models.BlogModels;

namespace StolenBlog.API.Validators
{
	public class BlogValidator : AbstractValidator<Blogs>
	{
		public BlogValidator()
		{
			this.RuleFor(_ => _.Description)
				.NotEmpty()
				.WithMessage("Cannot Create a blog without a Description");

			this.RuleFor(_ => _.UserId)
				.NotNull()
				.GreaterThan(0)
				.WithMessage("Invalid User");
		}
	}
}
