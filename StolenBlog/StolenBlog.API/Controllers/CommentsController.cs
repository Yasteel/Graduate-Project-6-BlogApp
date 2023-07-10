namespace StolenBlog.API.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	
	using StolenBlog.API.Interfaces;
	using StolenBlog.Models.BlogModels;
	using StolenBlog.Models.Dtos;

	[Route("api/[controller]")]
	[ApiController]
	public class CommentsController : ControllerBase
	{
		private readonly ICommentsService comments;
		private readonly IUserService userService;

		public CommentsController(ICommentsService comments, IUserService userService)
		{
			this.comments = comments;
			this.userService = userService;
		}

		// GET: api/Comments
		[HttpGet("{postId}")]
		public async Task<List<CommentResponseDto>> Get(int postId)
		{
			var comments = this.comments.GetAll().Result.Where(_ => _.PostId == postId).ToList();

			List<CommentResponseDto> commentDto = new ();

			foreach (var comment in comments)
			{
				var user = await this.userService.Get(comment.UserId);

				commentDto.Add(new ()
				{
					CommentId = comment.CommentId,
					PostId = comment.PostId,
					UserId = comment.UserId,
					Comment = comment.Comment,
					DateUpdated = comment.DateUpdated,
					DisplayName = user.DisplayName
				});
			}

			return commentDto;
		}

		// PUT: api/Comments/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] Comments comments)
		{

			comments.DateUpdated = DateTime.UtcNow;

			this.comments.Update(id, comments);
			return NoContent();
		}

		// POST: api/Comments
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] Comments comments)
		{
			comments.DateUpdated = DateTime.UtcNow;

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
