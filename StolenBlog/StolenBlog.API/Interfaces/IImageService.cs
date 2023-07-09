namespace StolenBlog.API.Interfaces
{
	using StolenBlog.Models.BlogModels;

	public interface IImageService : IGenericService<Images>
	{
		Task<int> Create(IFormFile image);
	}
}
