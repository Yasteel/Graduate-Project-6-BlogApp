namespace StolenBlog.API.Controllers
{
	using Microsoft.AspNetCore.Mvc;
    using StolenBlog.API.Interfaces;
    using StolenBlog.Models.BlogModels;

	[Route("api/[controller]")]
    [ApiController]
    public class BlogPostsController : ControllerBase
    {
        private readonly IBlogPostsService blogPostsService;

        public BlogPostsController(IBlogPostsService blogPostsService)
        {
            this.blogPostsService = blogPostsService;
        }

        // GET: api/BlogPosts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogPosts>>> Get()
        {
            return await this.blogPostsService.GetAll();
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
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] BlogPosts blogPosts)
        {
            this.blogPostsService.Update(id, blogPosts);

            return NoContent();
        }

        // POST: api/BlogPosts
        [HttpPost]
        public async Task<ActionResult<BlogPosts>> Post([FromBody] BlogPosts blogPosts)
        {
            this.blogPostsService.Create(blogPosts);

            return NoContent();
        }

        // DELETE: api/BlogPosts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            this.blogPostsService.Delete(id);
            return NoContent();
        }
    }
}
