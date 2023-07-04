namespace StolenBlog.API.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.EntityFrameworkCore;
    using StolenBlog.API.Interfaces;
    using StolenBlog.Models.BlogModels;

	[Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogsService blogsService;

        public BlogsController(IBlogsService blogsService)
        {
            this.blogsService = blogsService;
        }

        // GET: api/Blogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Blogs>>> Get()
        {
          return await this.blogsService.GetAll();
        }

        // GET: api/Blogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Blogs>> Get(int id)
        {
            var blogs = await this.blogsService.Get(id);

            if (blogs == null)
            {
                return NotFound();
            }

            return blogs;
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
