namespace StolenBlog.Models.BlogModels
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Diagnostics.CodeAnalysis;

	public class Users
	{
		[Key]
		[Column("pkUserId")]
		[NotNull]
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
