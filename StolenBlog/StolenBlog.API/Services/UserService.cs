using Microsoft.EntityFrameworkCore;
using StolenBlog.API.Data;
using StolenBlog.API.Interfaces;
using StolenBlog.Models.BlogModels;

namespace StolenBlog.API.Services
{
	public class UserService : GenericService<Users>, IUserService
	{
		private readonly AppDbContext dbContext;

		public UserService(AppDbContext dbContext)
			: base(dbContext)
        {
			this.dbContext = dbContext;
		}

		public async Task<Users> GetByUsername(string username)
		{
			return await this.dbContext.Users.FirstOrDefaultAsync(_ => _.Email == username);
		}
    }
}
