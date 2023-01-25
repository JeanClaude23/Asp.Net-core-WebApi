using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserApiController : ControllerBase
    {

        public static List<UserClass> users = new List<UserClass>
        {
                new UserClass
                {
                    id= 1,
                    username="kodo",
                    token="8f8a229e-12f7-4011-8bae-12a341788392",
                    email="jean@gmail.com"
                },
            new UserClass
                {
                    id= 2,
                    username="david",
                    token="8f8a229e-12f7-4011-8bae-12a341788392",
                    email="david@gmail.com"
                }
            };

        [HttpGet]
        public async Task<ActionResult<List<UserClass>>> Get()
        {

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<UserClass>>> Get(int id)
        {
            var user = users.Find(x => x.id == id);
            if (user == null) {
                return BadRequest("User not found");
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<List<UserClass>>> AddUser(UserClass user)
        {
            users.Add(user);
            return Ok(users);
        }
    }
}
