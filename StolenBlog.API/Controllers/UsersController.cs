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
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> Get()
        {
            return await this.usersService.GetAll();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> Get(int id)
        {
            var users = await this.usersService.Get(id);

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Users users)
        {
            this.usersService.Update(id, users);
            return NoContent();
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<Users>> Post([FromBody] Users users)
        {
            Console.WriteLine(JsonConvert.SerializeObject(users));
            this.usersService.Create(users);
            return NoContent();
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            this.usersService.Delete(id);
            return NoContent();
        }
    }
}
