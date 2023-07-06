namespace StolenBlog.Models.BlogModels
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class Blogs
	{
		[Key]
		[Column("pkBlogId")]
		[DataType("integer")]
		public int BlogId { get; set; }

		[Column("fkUserId")]
		[DataType("integer")]
		public int UserId { get; set;}

        [DataType(DataType.Text)]
        public string Name { get; set; }

		[DataType(DataType.Text)]
		public string Description { get; set; }

        //[Column("fkCategoryId")]
        //[DataType("integer")]
        //public int CategoryId { get; set; }

        [DataType("integer")]
		[Column("fkImageId")]
        public int? Image { get; set; }


    }
}
