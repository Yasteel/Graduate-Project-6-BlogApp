namespace StolenBlog.Models.BlogModels
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class Categories
	{
		[Key]
		[Column("pkCategoryId")]
		public int CategoryId { get; set; }

		public string CategoryName { get; set; }
	}
}
