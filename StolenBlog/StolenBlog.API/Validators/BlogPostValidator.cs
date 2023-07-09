namespace StolenBlog.API.Validators
{
	using FluentValidation;
	
	using StolenBlog.Models.BlogModels;


	public class BlogPostValidator : AbstractValidator<BlogPosts>
	{
		public BlogPostValidator()
		{
			this.RuleFor(x => x.BlogId)
			.NotNull()
			.GreaterThan(0);

			this.RuleFor(x => x.Description)
			.NotNull()
			.MinimumLength(1);
		}
	}
}
