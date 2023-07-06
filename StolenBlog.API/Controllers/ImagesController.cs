namespace StolenBlog.API.Controllers
{
	using Microsoft.AspNetCore.Mvc;
    using StolenBlog.API.Interfaces;
    using StolenBlog.Models.BlogModels;

	[Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageService imageService;

        public ImagesController(IImageService imageService)
        {
            this.imageService = imageService;
        }

        // GET: api/Images
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Images>>> Get()
        {
            return await this.imageService.GetAll();
        }

        // GET: api/Images/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Images>> Get(int id)
        {
            var images = await this.imageService.Get(id);

            if (images == null)
            {
                return NotFound();
            }

            return images;
        }

        // PUT: api/Images/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Images images)
        {
            this.imageService.Update(id, images);
            return NoContent();
        }

        // POST: api/Images
        [HttpPost]
        public IActionResult Post(IFormFile images)
        {
            return Ok(this.imageService.Create(images));
        }

        // DELETE: api/Images/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            this.imageService.Delete(id);
            return NoContent();
        }
    }
}
