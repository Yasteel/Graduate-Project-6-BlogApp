namespace StolenBlog.API.Services
{
	using Microsoft.EntityFrameworkCore;
	
	using StolenBlog.API.Data;
    using StolenBlog.API.Interfaces;
    using StolenBlog.Models.BlogModels;

    public class CommentsService : GenericService<Comments>, ICommentsService
    {
		private readonly AppDbContext context;

		public CommentsService(AppDbContext context)
            : base(context)
        {
			this.context = context;
		}


		public async Task<List<Comments>> getAllByBlogPostId(int postId)
		{
			return await this.context.Set<Comments>().Where(_ => _.PostId == postId).ToListAsync();
		}
	}
}
