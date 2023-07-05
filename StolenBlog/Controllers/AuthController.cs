namespace StolenBlog.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using StolenBlog.Data;
    using StolenBlog.Models;
    using StolenBlog.Models.BlogModels;
    using System.Text;

    public class AuthController : Controller
    {
        private readonly SignInManager<StolenBlogUser> signInManager;
        private readonly IUserStore<StolenBlogUser> userStore;
        private readonly UserManager<StolenBlogUser> userManager;
        private readonly IHttpClientFactory ClientFactory;

        //private readonly IUserEmailStore<StolenBlogUser> emailStore;
        private readonly ILogger<Login> logger;

        public AuthController
        (
            SignInManager<StolenBlogUser> signInManager,

            IUserStore<StolenBlogUser> userStore,
            UserManager<StolenBlogUser> userManager,
            IHttpClientFactory ClientFactory,
            ILogger<Login> logger
        )
        {
            this.signInManager = signInManager;
            this.userStore = userStore;
            this.userManager = userManager;
            this.ClientFactory = ClientFactory;
            this.logger = logger;
            //this.emailStore = GetEmailStore();

        }

        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {
            // This if statement catches any errors with the inputs if the front end validation does not catch it first
            if (!this.ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Input Error");
                return this.View(ModelState);
            }

            var result = await this.signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Login Failed.");
                return this.View();
            }

            return this.RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Register model)
        {
            if (!this.ModelState.IsValid)
            {
                this.ModelState.AddModelError(string.Empty, "Input Error");
                return this.View(ModelState);
            }

            var user = this.CreateUser();

            await this.userStore.SetUserNameAsync(user, model.User.Email, CancellationToken.None);
            //await this.emailStore.SetEmailAsync(user, model.User.Email, CancellationToken.None);

            var result = await this.userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    this.ModelState.AddModelError(string.Empty, error.Description);
                }
                return this.View(this.ModelState);
            }

            var completedRegister = await this.CompleteRegister(model.User);

            if (!completedRegister)
            {
                // Redirect to a page that just has their personal information to enter
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Failed to Completely Register User");

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }


            await this.signInManager.SignInAsync(user, isPersistent: false);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<bool> CompleteRegister(Users model)
        {
            var baseUrl = new Uri("https://localhost:7226/api/Users");
            var client = this.ClientFactory.CreateClient();
            var httpContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(baseUrl, httpContent);

            if (!response.IsSuccessStatusCode)
            {
                return false;
            }

            var user = JsonConvert.DeserializeObject<Users>(response.Content.ReadAsStringAsync().Result);
            return true;
        }

        private StolenBlogUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<StolenBlogUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(StolenBlogUser)}'. " +
                    $"Ensure that '{nameof(StolenBlogUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        //private IUserEmailStore<StolenBlogUser> GetEmailStore()
        //{
        //    if (!_userManager.SupportsUserEmail)
        //    {
        //        throw new NotSupportedException("The default UI requires a user store with email support.");
        //    }
        //    return (IUserEmailStore<StolenBlogUser>)_userStore;
        //}
    }
}
