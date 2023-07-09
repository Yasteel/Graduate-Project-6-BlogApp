namespace StolenBlog.API.Interfaces
{
	using StolenBlog.Models.BlogModels;

	public interface IUserService : IGenericService<Users>
	{
		Task<Users> GetByUsername(string username);
	}
}
