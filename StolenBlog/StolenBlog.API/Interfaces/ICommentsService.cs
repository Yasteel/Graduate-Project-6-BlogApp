﻿namespace StolenBlog.API.Interfaces
{
	using StolenBlog.Models.BlogModels;

	public interface ICommentsService : IGenericService<Comments>
	{
		Task<List<Comments>> getAllByBlogPostId(int postId);
	}
}
