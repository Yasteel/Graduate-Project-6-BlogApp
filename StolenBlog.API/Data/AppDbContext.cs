namespace StolenBlog.API.Data
{
	using Microsoft.EntityFrameworkCore;
	using StolenBlog.Models.BlogModels;

	public class AppDbContext : DbContext 
	{
        public AppDbContext(DbContextOptions<AppDbContext> context)
            : base(context)
        {          
        }

		public DbSet<BlogPosts> BlogPosts { get; set; }

		public DbSet<Blogs> Blogs { get; set; }

		public DbSet<Categories> Categories { get; set; }

		public DbSet<Comments> Comments { get; set; }

		public DbSet<Images> Images { get; set; }

		public DbSet<Users> Users { get; set; }
	}
}
