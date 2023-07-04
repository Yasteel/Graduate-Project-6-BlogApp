using StolenBlog.API.Data;
using StolenBlog.API.Interfaces;
using StolenBlog.Models.BlogModels;

namespace StolenBlog.API.Services
{
    public class BlogsService : GenericService<Blogs>, IBlogsService
    {
        public BlogsService(AppDbContext context)
            : base(context)
        {
            
        }
    }
}
