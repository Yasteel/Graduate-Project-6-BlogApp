namespace StolenBlog.API.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using StolenBlog.API.Interfaces;
	using StolenBlog.Models.BlogModels;

	[Route("api/[controller]")]
	[ApiController]
	public class BlogsController : ControllerBase
	{
		private readonly IBlogsService blogsService;
		private readonly IUserService userService;
		private readonly ICacheService cacheService;

		public BlogsController
		(
			IBlogsService blogsService, 
			IUserService userService, 
			ICacheService cacheService
		)
		{
			this.blogsService = blogsService;
			this.userService = userService;
			this.cacheService = cacheService;
		}

		// GET: api/Blogs
		[HttpGet("{username}")]
		public async Task<ActionResult<IEnumerable<Blogs>>> Get(string username)
		{

			var user = await this.userService.GetByUsername(username);

			// check if anything is in Redis

			try
			{
				var blogsFromRedis = this.cacheService.GetData<Blogs>($"{user.UserId}-blogs");

				if (blogsFromRedis is not null)
				{
					Console.BackgroundColor = ConsoleColor.Green;
					Console.WriteLine("\n====================\nGot From Redis\n====================\n");
					Console.BackgroundColor = ConsoleColor.Black;
					return Ok(blogsFromRedis);
				}

				var blogs = this.blogsService.GetAll().Result.Where(_ => _.UserId == user.UserId).ToList();

				if (blogs is null)
				{
					return NoContent();
				}

				this.cacheService.SaveData<Blogs>($"{user.UserId}-blogs", blogs, TimeSpan.FromMinutes(15));

				return Ok(blogs);
			}
			catch (StackExchange.Redis.RedisConnectionException ex)
			{
				Console.WriteLine("Redis is Down");

				var blogs = this.blogsService.GetAll().Result.Where(_ => _.UserId == user.UserId).ToList();

				if (blogs is null)
				{
					return NoContent();
				}

				return Ok(blogs);
			}

			

			
		}


		// PUT: api/Blogs/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] Blogs blogs)
		{
			this.blogsService.Update(id, blogs);

			return NoContent();
		}

		// POST: api/Blogs
		[HttpPost]
		public async Task<ActionResult<Blogs>> Post([FromBody] Blogs blogs)
		{
			this.blogsService.Create(blogs);

			return NoContent();
		}

		// DELETE: api/Blogs/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			this.blogsService.Delete(id);
			return NoContent();
		}
	}
}
