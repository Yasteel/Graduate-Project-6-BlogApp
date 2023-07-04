namespace StolenBlog.API.Services
{
    using StolenBlog.API.Data;
    using StolenBlog.API.Interfaces;
    using StolenBlog.Models.BlogModels;

    public class ImageService : GenericService<Images>, IImageService
    {
        public ImageService(AppDbContext context)
            : base(context)
        {
        }
    }
}
