namespace StolenBlog.API.Controllers
{
	using Microsoft.AspNetCore.Mvc;
    using StolenBlog.API.Interfaces;
    using StolenBlog.Models.BlogModels;

	//[Route("api/[controller]")]
 //   [ApiController]
    public class CategoriesController : ControllerBase
    {
        //private readonly ICategoriesService categoriesService;

        //public CategoriesController(ICategoriesService categoriesService)
        //{
        //    this.categoriesService = categoriesService;
        //}

        //// GET: api/Categories
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Categories>>> Get()
        //{
        //    return await this.categoriesService.GetAll();
        //}

        //// GET: api/Categories/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Categories>> Get(int id)
        //{
        //    var categories = await this.categoriesService.Get(id);

        //    if (categories == null)
        //    {
        //        return NotFound();
        //    }

        //    return categories;
        //}

        //// PUT: api/Categories/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> Put(int id, [FromBody] Categories categories)
        //{
        //    this.categoriesService.Update(id, categories);
        //    return NoContent();
        //}

        //// POST: api/Categories
        //[HttpPost]
        //public async Task<ActionResult<Categories>> Post([FromBody] Categories categories)
        //{
        //    this.categoriesService.Create(categories);
        //    return NoContent();
        //}

        //// DELETE: api/Categories/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    this.categoriesService.Delete(id);
        //    return NoContent();
        //}
    }
}
