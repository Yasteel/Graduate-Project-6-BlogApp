namespace StolenBlog.API.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.EntityFrameworkCore;
	using StolenBlog.API.Data;
	using StolenBlog.Models.BlogModels;

	[Route("api/[controller]")]
    [ApiController]
    public class BlogPostsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BlogPostsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/BlogPosts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogPosts>>> GetBlogPosts()
        {
          if (_context.BlogPosts == null)
          {
              return NotFound();
          }
            return await _context.BlogPosts.ToListAsync();
        }

        // GET: api/BlogPosts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BlogPosts>> GetBlogPosts(int id)
        {
          if (_context.BlogPosts == null)
          {
              return NotFound();
          }
            var blogPosts = await _context.BlogPosts.FindAsync(id);

            if (blogPosts == null)
            {
                return NotFound();
            }

            return blogPosts;
        }

        // PUT: api/BlogPosts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlogPosts(int id, BlogPosts blogPosts)
        {
            if (id != blogPosts.PostId)
            {
                return BadRequest();
            }

            _context.Entry(blogPosts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogPostsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BlogPosts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BlogPosts>> PostBlogPosts(BlogPosts blogPosts)
        {
          if (_context.BlogPosts == null)
          {
              return Problem("Entity set 'AppDbContext.BlogPosts'  is null.");
          }
            _context.BlogPosts.Add(blogPosts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBlogPosts", new { id = blogPosts.PostId }, blogPosts);
        }

        // DELETE: api/BlogPosts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlogPosts(int id)
        {
            if (_context.BlogPosts == null)
            {
                return NotFound();
            }
            var blogPosts = await _context.BlogPosts.FindAsync(id);
            if (blogPosts == null)
            {
                return NotFound();
            }

            _context.BlogPosts.Remove(blogPosts);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BlogPostsExists(int id)
        {
            return (_context.BlogPosts?.Any(e => e.PostId == id)).GetValueOrDefault();
        }
    }
}
