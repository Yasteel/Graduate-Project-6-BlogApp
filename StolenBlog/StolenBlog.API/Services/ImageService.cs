using StolenBlog.API.Data;
using StolenBlog.API.Interfaces;
using StolenBlog.Models.BlogModels;

namespace StolenBlog.API.Services
{
    public class ImageService : GenericService<Images>, IImageService
    {
        private readonly AppDbContext context;
        private readonly IWebHostEnvironment environment;

        public ImageService(AppDbContext context, IWebHostEnvironment environment)
            : base(context)
        {
            this.context = context;
            this.environment = environment;
        }

        public new async Task<int> Create(IFormFile image)
        {
            // Upload File To server Folder
            var path = Directory.GetCurrentDirectory();
            path = Path.Combine(path, "uploads");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var fileName = $"{Guid.NewGuid()}{Path.GetFileName(image.FileName)}";

            var stream = new FileStream(Path.Combine(path, fileName), FileMode.Create);
            image.CopyTo(stream);


            // Add to Database
            Images newImage = new()
            {
                ImagePath = fileName
            };

            await this.context.Set<Images>().AddAsync(newImage);
            this.context.SaveChanges();
            return newImage.ImageId;
        }
    }
}
