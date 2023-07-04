namespace StolenBlog.Models
{
	using StolenBlog.Models.BlogModels;
    using System.ComponentModel.DataAnnotations;

    public class Register
	{
        public Users User { get; set; }


        [DataType(DataType.Password)]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Compare(nameof(this.Password), ErrorMessage = "Passwords Do Not Match")]
        public string RepeatPassword { get; set; }


    }
}
