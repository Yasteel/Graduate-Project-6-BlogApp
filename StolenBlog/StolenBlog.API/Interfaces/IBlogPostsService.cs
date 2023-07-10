namespace StolenBlog.API.Interfaces
{
	using StolenBlog.Models.BlogModels;

	public interface IBlogPostsService : IGenericService<BlogPosts>
	{
		Task<List<BlogPosts>> GetBlogPostsByBlogId(int blogId);
	}
}
