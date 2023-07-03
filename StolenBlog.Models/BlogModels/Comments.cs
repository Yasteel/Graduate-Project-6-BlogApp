namespace StolenBlog.Models.BlogModels
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class Comments
	{
		[Key]
		[Column("pkCommentId")]
		public int CommentId { get; set; }

		[Column("fkPostId")]
		public int PostId { get; set; }

		[Column("fkUserId")]
		public int UserId { get; set; }

		public string Comment { get; set; }

		public DateTime DateUpdated { get; set; }
	}
}
