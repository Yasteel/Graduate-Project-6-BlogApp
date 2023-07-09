namespace StolenBlog.API.Services
{
    using StolenBlog.API.Data;
    using StolenBlog.API.Interfaces;
    using StolenBlog.Models.BlogModels;

    public class BlogsService : GenericService<Blogs>, IBlogsService
    {
        public BlogsService(AppDbContext context)
            : base(context)
        {

        }
    }
}
