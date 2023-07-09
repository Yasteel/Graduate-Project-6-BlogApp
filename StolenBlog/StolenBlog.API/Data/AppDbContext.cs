namespace StolenBlog.API.Data
{
	using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore;
	using StolenBlog.Models.BlogModels;

	public class AppDbContext : IdentityDbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> context)
		: base(context)
		{
		}

		public DbSet<BlogPosts> BlogPosts { get; set; }

		public DbSet<Blogs> Blogs { get; set; }

		public DbSet<Comments> Comments { get; set; }

		public DbSet<Images> Images { get; set; }

		public DbSet<Users> Users { get; set; }
	}
}
