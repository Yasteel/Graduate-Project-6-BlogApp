using System.ComponentModel.DataAnnotations;

namespace StolenBlog.Models.DTOs
{
	public class RegistrationRequestDto
	{
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password), ErrorMessage = "Passwords Do Not Match")]
        public string RepeatPassword { get; set; }

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
