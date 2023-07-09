namespace StolenBlog.Models.BlogModels
{
	using System.ComponentModel.DataAnnotations.Schema;
	using System.ComponentModel.DataAnnotations;

	public class Blogs
	{
		[Key]
		[Column("pkBlogId")]
		[DataType("integer")]
		public int BlogId { get; set; }

		[Column("fkUserId")]
		[DataType("integer")]
		public int UserId { get; set; }

		[DataType(DataType.Text)]
		public string Name { get; set; }

		[DataType(DataType.Text)]
		public string Description { get; set; }

		[DataType("integer")]
		[Column("fkImageId")]
		public int? Image { get; set; }


	}
}
