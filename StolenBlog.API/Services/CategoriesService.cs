namespace StolenBlog.API.Services
{
    using StolenBlog.API.Data;
    using StolenBlog.API.Interfaces;
    using StolenBlog.Models.BlogModels;

    public class CategoriesService : GenericService<Categories>, ICategoriesService
    {
        public CategoriesService(AppDbContext context)
            : base(context)
        {
        }
    }
}
