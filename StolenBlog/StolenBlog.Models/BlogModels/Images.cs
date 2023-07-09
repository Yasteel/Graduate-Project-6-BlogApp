namespace StolenBlog.Models.BlogModels
{
	using System.ComponentModel.DataAnnotations.Schema;
	using System.ComponentModel.DataAnnotations;

	public class Images
	{
		[Key]
		[Column("pkImageId")]
		[DataType("integer")]
		public int ImageId { get; set; }

		public string ImagePath { get; set; }


	}
}
