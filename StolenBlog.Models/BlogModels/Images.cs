namespace StolenBlog.Models.BlogModels
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;


	public class Images
	{
        [Key]
        [Column("pkImageId")]
        [DataType("integer")]
        public int ImageId { get; set; }

        public string ImagePath { get; set; }


    }
}
