namespace StolenBlog.Models.Dtos
{
	public class BlogResponseDto
	{
		public int BlogId { get; set; }

		public int UserId { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public int? Image { get; set; }

		public int PostCount { get; set; }
	}
}
