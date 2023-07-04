namespace StolenBlog.API.Services
{
    using StolenBlog.API.Data;
    using StolenBlog.API.Interfaces;
    using StolenBlog.Models.BlogModels;

    public class UsersService : GenericService<Users>, IUsersService
    {
        public UsersService(AppDbContext context)
            : base(context)
        {
        }
    }
}
