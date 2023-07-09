namespace StolenBlog.API.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	
	using StolenBlog.API.Interfaces;
	using StolenBlog.Models.BlogModels;

	[Route("api/[controller]")]
	[ApiController]
	public class CommentsController : ControllerBase
	{
		private readonly ICommentsService comments;

		public CommentsController(ICommentsService comments)
		{
			this.comments = comments;
		}

		// GET: api/Comments
		[HttpGet("{postId}")]
		public async Task<ActionResult<List<Comments>>> Get(int postId)
		{
			return this.comments.GetAll().Result.Where(_ => _.PostId == postId).ToList();
		}

		// GET: api/Comments/5
		//[HttpGet("{id}")]
		//public async Task<ActionResult<Comments>> Get(int id)
		//{
		//	var comments = await this.comments.Get(id);

		//	if (comments == null)
		//	{
		//		return NotFound();
		//	}

		//	return comments;
		//}

		// PUT: api/Comments/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] Comments comments)
		{
			this.comments.Update(id, comments);
			return NoContent();
		}

		// POST: api/Comments
		[HttpPost]
		public async Task<ActionResult<Comments>> Post([FromBody] Comments comments)
		{
			this.comments.Create(comments);
			return NoContent();
		}

		// DELETE: api/Comments/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteComments(int id)
		{
			this.comments.Delete(id);
			return NoContent();
		}
	}
}
