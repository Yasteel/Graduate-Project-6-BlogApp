namespace StolenBlog.Models.Dtos
{
	public class CommentResponseDto
	{
		public int CommentId { get; set; }

		public int PostId { get; set; }

		public int UserId { get; set; }

		public string DisplayName { get; set; }

		public string Comment { get; set; }

		public DateTime DateUpdated { get; set; }
	}
}
