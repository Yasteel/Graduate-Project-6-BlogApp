namespace StolenBlog.API.Services
{
	using Microsoft.EntityFrameworkCore;
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


		public async Task<List<BlogPosts>> GetBlogPostsByBlogId(int blogId)
		{
			return await this.context.Set<BlogPosts>().Where(_ => _.BlogId == blogId).ToListAsync();
		}
	}
}
