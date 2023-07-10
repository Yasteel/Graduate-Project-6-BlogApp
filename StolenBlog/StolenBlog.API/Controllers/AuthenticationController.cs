namespace StolenBlog.API.Controllers
{
	using Azure.Core.Pipeline;
	using FluentValidation;
	using Microsoft.AspNetCore.Authentication.JwtBearer;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.IdentityModel.Tokens;
	using StolenBlog.API.Configurations;
	using StolenBlog.API.Interfaces;
	using StolenBlog.Models.AuthModels;
	using StolenBlog.Models.BlogModels;
	using StolenBlog.Models.Dtos;
	using StolenBlog.Models.DTOs;
	using System.IdentityModel.Tokens.Jwt;
	using System.Security.Claims;
	using System.Text;

	//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)] // To be Added To Other Endpoints
	[Route("api/[controller]")]
	[ApiController]
	public class AuthenticationController : ControllerBase
	{
		private readonly UserManager<IdentityUser> userManager;
		private readonly SignInManager<IdentityUser> signInManager;
		private readonly IConfiguration configuration;

		private readonly IUserService userService;
		private readonly IValidator<RegistrationRequestDto> validator;

		public AuthenticationController
		(
			UserManager<IdentityUser> userManager,
			SignInManager<IdentityUser> signInManager,
			IConfiguration configuration,
			IUserService userService,
			IValidator<RegistrationRequestDto> validator
		)
        {
			this.userManager = userManager;
			this.signInManager = signInManager;
			this.configuration = configuration;
			this.userService = userService;
			this.validator = validator;
		}

		[HttpPost]
		[Route("Register")]
		public async Task<IActionResult> Post([FromBody] RegistrationRequestDto registrationRequest)
		{
			//if(!this.ModelState.IsValid)
			//{
			//	return BadRequest(this.ModelState);
			//}

			var validationResult = await this.validator.ValidateAsync(registrationRequest);

			if (!validationResult.IsValid)
			{
				return BadRequest(validationResult.Errors);
			}


			var userExist = await this.userManager.FindByEmailAsync(registrationRequest.Email);

			if (userExist != null)
			{
				return this.BadRequest(new AuthResult()
				{
					Result = false,
					Errors = new List<string>()
					{
						"Email Already Exists"
					}
				});
			}

			var newUser = new IdentityUser()
			{
				Email = registrationRequest.Email,
				UserName = registrationRequest.Email
			};

			var createResult = await this.userManager.CreateAsync(newUser, registrationRequest.Password);

			if (!createResult.Succeeded)
			{
				return this.BadRequest(new AuthResult()
				{
					Errors = new List<string>()
					{
						"Server Error"
					},
					Result = false
				});
			}

			var blogUser = new Users()
			{
				Email = registrationRequest.Email,
				FirstName = registrationRequest.FirstName,
				Surname = registrationRequest.Surname,
				DisplayName = registrationRequest.DisplayName,
				DateOfBirth = registrationRequest.DateOfBirth,
			};

			this.userService.Create(blogUser);

			var token = GenerateJwtToken(newUser);

			return Ok(new AuthResult()
			{
				Result = true,
				Token = token
			});
		}


		[HttpPost]
		[Route("Login")]
		public async Task<IActionResult> Post([FromBody] LoginRequestDto loginRequest)
		{
			if(!this.ModelState.IsValid)
			{
				return this.BadRequest(new AuthResult()
				{
					// Need to get errors from modelstate and insert into below
					// for now its fine
					Errors = new List<string>()
					{
						"Invalid Payload"
					},
					Result = false
				});
			}

			var existingUser = await this.userManager.FindByEmailAsync(loginRequest.Email);

			if(existingUser == null)
			{
				return this.BadRequest(new AuthResult()
				{
					Errors = new List<string>()
					{
						"Invalid Credentials"
					},
					Result = false
				});
			}			

			var result = await this.signInManager.PasswordSignInAsync(existingUser, loginRequest.Password, isPersistent: loginRequest.RememberMe, lockoutOnFailure: false);
			if (!result.Succeeded)
			{
				return this.BadRequest(new AuthResult()
				{
					Errors = new List<string>()
					{
						"Invalid Credentials"
					},
					Result = false
				});
			}

			var jwtToken = GenerateJwtToken(existingUser);
			return Ok(new AuthResult()
			{
				Token = jwtToken,
				Result = true
			});


		}

		[HttpGet]
		[Route("ReadToken/{tokenString}")]
        public string ReadToken(string tokenString)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var token = jwtTokenHandler.ReadJwtToken(tokenString);

            string username = string.Empty;

            foreach (var claim in token.Claims)
            {
                if (claim.Type.Equals("sub"))
                {
                    username = claim.Value;
                }
            }

            return username;
        }

		[HttpPost]
		[Route("Logout")]
		public async Task<IActionResult> Logout()
		{
			await this.signInManager.SignOutAsync();

			return this.Ok();
		}

		[HttpGet]
		[Route("UserSignedIn")]
		public bool UserSignedIn()
		{
			return this.User.Identity.IsAuthenticated; // need to find out if user is actually signed in 
		}

        private string GenerateJwtToken(IdentityUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler(); // responsible for creating the token

            //var key = Encoding.UTF8.GetBytes(this.jwtConfig.Secret);
            var key = Encoding.UTF8.GetBytes(this.configuration.GetSection("JwtConfig:Secret").Value);

            // Token Descriptor

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                // Payload Information
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("id", user.Id),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToFileTimeUtc().ToString())
                }),

                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }


    }
}
