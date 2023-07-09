using StolenBlog.Models.BlogModels;

namespace StolenBlog.Models.Dtos
{
	public class BlogPostResponseDto
	{

		public int PostId { get; set; }

		public int BlogId { get; set; }

		public string? Heading { get; set; }

		public string Description { get; set; }

		public int? ImageId { get; set; }

		public DateTime DateUpdated { get; set; }

		public Users users { get; set; }
	}
}
