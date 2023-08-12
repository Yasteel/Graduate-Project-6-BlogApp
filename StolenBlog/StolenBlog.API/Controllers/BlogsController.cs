namespace StolenBlog.API.Controllers
{
	using FluentValidation;
	using Microsoft.AspNetCore.Authentication.JwtBearer;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.IdentityModel.Tokens;
	using StolenBlog.API.Interfaces;
	using StolenBlog.Models.AuthModels;
	using StolenBlog.Models.BlogModels;
	using StolenBlog.Models.Dtos;
	using System.Net;
	using static System.Net.Mime.MediaTypeNames;

	[Route("api/[controller]")]
	[ApiController]
	public class BlogsController : ControllerBase
	{
		private readonly IBlogsService blogsService;
		private readonly IUserService userService;
		private readonly ICacheService cacheService;
		private readonly IBlogPostsService blogPostsService;
		private readonly ICommentsService commentsService;
		private readonly IValidator<Blogs> validator;

		public BlogsController
		(
			IBlogsService blogsService, 
			IUserService userService, 
			ICacheService cacheService,
			IBlogPostsService blogPostsService,
			ICommentsService commentsService,
			IValidator<Blogs> validator
		)
		{
			this.blogsService = blogsService;
			this.userService = userService;
			this.cacheService = cacheService;
			this.blogPostsService = blogPostsService;
			this.commentsService = commentsService;
			this.validator = validator;
		}

		// GET: api/Blogs
		[HttpGet("{username?}")]
		public async Task<ActionResult<IEnumerable<Blogs>>> Get(string? username)
		{
			if (username.IsNullOrEmpty())
			{
				return BadRequest(new
				{
					new ArgumentException("cannot be null or empty", nameof(username)).Message, 
					StatusCode = HttpStatusCode.BadRequest.ToString(),
					Code = HttpStatusCode.BadRequest,
				});
			}

			var user = await this.userService.GetByUsername(username);

			// check if anything is in Redis

			if (user is null)
			{
				return BadRequest(new
				{
					Message = $"{username} not found.",
					StatusCode = HttpStatusCode.BadRequest.ToString(),
					Code = HttpStatusCode.BadRequest,
				});
			}

			try
			{
				
				var blogsFromRedis = this.cacheService.GetData<Blogs>($"{user.UserId}-blogs") ?? null;

				if (blogsFromRedis is not null)
				{

					Console.BackgroundColor = ConsoleColor.Green;
					Console.WriteLine("got from redis");
					Console.BackgroundColor = ConsoleColor.Black;


					// Got Users' Blogs from Cache
					return Ok(this.getBlogResponseDto(blogsFromRedis));
				}

				var blogs = this.blogsService.GetAll().Result.Where(_ => _.UserId == user.UserId).ToList();

				if (blogs is null)
				{
					return NoContent();
				}

				this.cacheService.SaveData<Blogs>($"{user.UserId}-blogs", blogs, TimeSpan.FromMinutes(15));

				return Ok(this.getBlogResponseDto(blogs));
			}
			catch (StackExchange.Redis.RedisConnectionException ex)
			{
				Console.WriteLine("Redis is Down");

				var blogs = this.blogsService.GetAll().Result.Where(_ => _.UserId == user.UserId).ToList();

				if (blogs is null)
				{
					return NoContent();
				}

				return Ok(this.getBlogResponseDto(blogs));
			}
			
		}


		// PUT: api/Blogs/5
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] Blogs blogs)
		{
			var result = this.validator.Validate(blogs);

			if (!result.IsValid)
			{
				return BadRequest(result.Errors);
			}


			this.blogsService.Update(id, blogs);

			return NoContent();
		}

		// POST: api/Blogs
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
		[HttpPost]
		public async Task<ActionResult<Blogs>> Post([FromBody] Blogs blogs)
		{
			this.blogsService.Create(blogs);

			return NoContent();
		}

		// DELETE: api/Blogs/5
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{

			var blogPosts = await this.blogPostsService.GetBlogPostsByBlogId(id);

			if (blogPosts is null)
			{
				// No Related Posts to this blog
				this.blogsService.Delete(id);
				return NoContent();
			}

			// check for comments related to above posts

			var comments = new List<Comments>();

			foreach (var post in blogPosts)
			{
				var commentsForPost = await this.commentsService.getAllByBlogPostId(post.PostId);

				if (commentsForPost is not null)
				{
					comments.Concat(commentsForPost);
				}

			}

			// Delete from lowest level first - Comments -> Posts -> Blog

			foreach (var comment in comments)
			{
				this.commentsService.Delete(comment.CommentId);
			}


			foreach(var post in blogPosts)
			{
				this.blogPostsService.Delete(post.PostId);
			}

			this.blogsService.Delete(id);
			return NoContent();
		}

		private List<BlogResponseDto> getBlogResponseDto(List<Blogs> blogs)
		{
			//return this.blogPostsService.GetAll().Result.Count(_ => _.BlogId == blogId);

			List<BlogResponseDto> blogsResponse = new();

			foreach (var blog in blogs)
			{
				blogsResponse.Add(new()
				{
					BlogId = blog.BlogId,
					UserId = blog.UserId,
					Name = blog.Name,
					Description = blog.Description,
					Image = blog.Image,
					PostCount = this.blogPostsService.GetAll().Result.Count(_ => _.BlogId == blog.BlogId)
				});
			}


			return blogsResponse;
		}

	}
}
