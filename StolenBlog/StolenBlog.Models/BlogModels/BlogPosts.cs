namespace StolenBlog.Models.BlogModels
{
	using System.ComponentModel.DataAnnotations.Schema;
	using System.ComponentModel.DataAnnotations;

	public class BlogPosts
	{
		[Key]
		[Column("pkPostId")]
		[DataType("integer")]
		public int PostId { get; set; }

		[Column("fkBlogId")]
		[DataType("integer")]
		public int BlogId { get; set; }

		[DataType(DataType.Text)]
		public string? Heading { get; set; }

		[DataType(DataType.Text)]
		public string Description { get; set; }

		[Column("fkImageId")]
		[DataType("integer")]
		public int? ImageId { get; set; }

		[DataType(DataType.DateTime)]
		public DateTime DateUpdated { get; set; }
	}
}
