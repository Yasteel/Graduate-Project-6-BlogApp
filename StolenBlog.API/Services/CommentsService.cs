namespace StolenBlog.API.Services
{
    using StolenBlog.API.Data;
    using StolenBlog.API.Interfaces;
    using StolenBlog.Models.BlogModels;

    public class CommentsService : GenericService<Comments>, ICommentsService
    {
        public CommentsService(AppDbContext context)
            : base(context)
        {
        }
    }
}
