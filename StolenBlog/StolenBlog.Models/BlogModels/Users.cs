namespace StolenBlog.Models.BlogModels
{
	using System.ComponentModel.DataAnnotations.Schema;
	using System.ComponentModel.DataAnnotations;

	public class Users
	{
		[Key]
		[Column("pkUserId")]
		[DataType("integer")]
		public int UserId { get; set; }

		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[DataType(DataType.Text)]
		public string FirstName { get; set; }

		[DataType(DataType.Text)]
		public string Surname { get; set; }

		[DataType(DataType.Text)]
		public string DisplayName { get; set; }

		[DataType(DataType.DateTime)]
		public DateTime DateOfBirth { get; set; }
	}
}
