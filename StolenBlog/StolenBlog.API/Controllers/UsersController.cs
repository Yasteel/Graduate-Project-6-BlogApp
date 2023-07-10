namespace StolenBlog.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Newtonsoft.Json;
    
    using StolenBlog.API.Interfaces;
    using StolenBlog.Models.BlogModels;

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Users>>> Get()
        {
            return await this.userService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> Get(int id)
        {
            var user = await this.userService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

		[HttpGet]
        [Route("GetByUsername/{email}")]
		public async Task<ActionResult<Users>> Get(string email)
		{
            var user = await this.userService.GetByUsername(email);

			if (user == null)
			{
				return NotFound();
			}

			return user;
		}

		// PUT: api/Users/5
		[HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] Users users)
        {
            this.userService.Update(id, users);
            return NoContent();
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<Users>> Post([FromBody] Users users)
        {
            Console.WriteLine(JsonConvert.SerializeObject(users));
            this.userService.Create(users);
            return NoContent();
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            this.userService.Delete(id);
            return NoContent();
        }
    }
}
