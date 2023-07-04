namespace StolenBlog.Models
{
	using StolenBlog.Models.BlogModels;

	public class Register
	{
        public Users User { get; set; }

        public string Password { get; set; }

        public string RepeatPassword { get; set; }


    }
}
