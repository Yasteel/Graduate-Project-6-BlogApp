namespace StolenBlog.API.Controllers
{
	using FluentValidation;
	using Microsoft.AspNetCore.Authentication.JwtBearer;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	using StolenBlog.API.Interfaces;
	using StolenBlog.Models.BlogModels;
	using StolenBlog.Models.Dtos;

	[Route("api/[controller]")]
	[ApiController]
	public class BlogPostsController : ControllerBase
	{
		private readonly IBlogPostsService blogPostsService;
		private readonly IValidator<BlogPosts> validator;
		private readonly IBlogsService blogsService;
		private readonly IUserService userService;

		public BlogPostsController
		(
			IBlogPostsService blogPostsService, 
			IValidator<BlogPosts> validator,
			IBlogsService blogsService,
			IUserService userService
		)
		{
			this.blogPostsService = blogPostsService;
			this.validator = validator;
			this.blogsService = blogsService;
			this.userService = userService;
		}

		// GET: api/BlogPosts
		[HttpGet]
		public async Task<ActionResult<List<BlogPostResponseDto>>> Get()
		{
			var blogPosts = await this.blogPostsService.GetAll();

			if(blogPosts is null)
			{
				return this.NoContent();
			}


			var blogPostResponse = new List<BlogPostResponseDto>();

			foreach ( var post in blogPosts )
			{
				var blog = await this.blogsService.Get(post.BlogId);
				var user = await this.userService.Get(blog.UserId);

				blogPostResponse.Add(new()
				{
					PostId = post.PostId,
					BlogId = post.BlogId,
					Heading = post.Heading,
					Description = post.Description,
					ImageId = post.ImageId,
					DateUpdated = post.DateUpdated,
					users = user
					
				});
			}

			return blogPostResponse;

		}

		// GET: api/BlogPosts/5
		[HttpGet("{id}")]
		public async Task<ActionResult<BlogPosts>> Get(int id)
		{
			var blogPosts = await this.blogPostsService.Get(id);

			if (blogPosts == null)
			{
				return NotFound();
			}

			return blogPosts;
		}

		// PUT: api/BlogPosts/5
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] BlogPosts blogPosts)
		{
			var updateItem = this.blogPostsService.Get(id);

			if(updateItem is null)
			{
				return this.NotFound(new List<string>()
				{
					"Server Error - Post Not Found"
				});
			}

			var validationResult = this.validator.Validate(blogPosts);
			

			if (!validationResult.IsValid)
			{
				return this.BadRequest(validationResult.Errors);
			}
			blogPosts.DateUpdated = DateTime.Now;
			this.blogPostsService.Update(id, blogPosts);
			return Ok();
		}

		// POST: api/BlogPosts
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
		[HttpPost]
		public async Task<ActionResult<BlogPosts>> Post([FromBody] BlogPosts blogPosts)
		{
			var result = await this.validator.ValidateAsync(blogPosts);

			if (!result.IsValid)
			{
				return this.BadRequest(result.Errors);
			}

			blogPosts.DateUpdated = DateTime.Now;

			this.blogPostsService.Create(blogPosts);
			return Ok();
		}

		// DELETE: api/BlogPosts/5
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var deleteItem = this.blogPostsService.Get(id);

			if(deleteItem is null)
			{
				return this.NotFound(new List<string>()
				{
					"Server Error - Post Not Found"
				});
			}

			this.blogPostsService.Delete(id);
			return Ok();
		}
	}
}
