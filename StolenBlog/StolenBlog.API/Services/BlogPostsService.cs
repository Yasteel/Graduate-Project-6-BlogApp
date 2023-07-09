namespace StolenBlog.API.Services
{
	using StolenBlog.API.Data;
	using StolenBlog.API.Interfaces;
	using StolenBlog.Models.BlogModels;


	public class BlogPostsService : GenericService<BlogPosts>, IBlogPostsService
	{
		private readonly AppDbContext context;

		public BlogPostsService(AppDbContext context)
			: base(context)
		{
			this.context = context;
		}
	}
}
