using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestUserController : ControllerBase
    {
        private readonly MS_LearningsContext _context;

        public TestUserController(MS_LearningsContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("api/[controller]/attributes/{username}")]
        public async Task<IActionResult> GetByUserName([FromRoute] string username)
        {
            var webApiUsers = await _context.WebApiUsers.ToListAsync();
            var webApiUser = webApiUsers.Find(x => x.Username == username);
            if (webApiUser == null)
            {
                return BadRequest("User not found");
            }
            return Ok(webApiUser);
        }
        [HttpGet]
        public async Task<ActionResult<List<WebApiUser>>> GetUsers()
        {
            return Ok(await _context.WebApiUsers
                .ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiUser>> GetUserbyId(int id)
        {
            var user =await _context.WebApiUsers.FindAsync(id);
            if(user == null)
            {
                return BadRequest("User not found");
            }
            //return Ok(user);
            return user;
        }

        //[HttpPost]
        //public async Task<ActionResult<List<WebApiUser>>> AddUser(WebApiUser user)
        //{
        //    _context.WebApiUsers.Add(user);
        //    await _context.SaveChangesAsync();
        //    return Ok(await _context.WebApiUsers.ToListAsync());

        //}
        [HttpPost("cookies/{username}")]
        public async Task<ActionResult<string>> SetCookieAsync([FromRoute] String username)
        {
            var webApiUsers = await _context.WebApiUsers.ToListAsync();
            var webApiUserId = webApiUsers.Find(x => x.Username == username).Id.ToString();
            var cookie = new Cookie("AccountID", webApiUserId);
            cookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Append("AccountID", webApiUserId, new CookieOptions { Expires = DateTime.Now.AddDays(1) });
            //HttpContext.Session.SetString("AccountID", webApiUserId);
            var newCookies = new[] { string.Format("AccountID={0}", webApiUserId) };
            Request.Headers["Cookie"] = newCookies;
            if (Request.Cookies["AccountID"] != null)
                return Ok("The cookie is saved");
            return BadRequest("The cookie wasn't saved");
        }

        [HttpGet("cookies")]
        public string GetCookie()
        {
            return Request.Cookies["AccountID"]!;
        }

        [HttpDelete("cookies")]
        public ActionResult DeleteCookie()
        {
            Response.Cookies.Delete("AccountID");
            Request.Headers["Cookie"] = "";
            if (Request.Cookies["AccountID"] == null)
                return Ok("The cookie was successfully deleted");
            return BadRequest("The cookie didn't get deleted");
        }

        [HttpPut]
        public async Task<ActionResult<List<WebApiUser>>> UpdateUser(WebApiUser user)
        {
            var upduser = await _context.WebApiUsers.FindAsync(user.Id);
            if (upduser == null)

                return BadRequest("User not found");
            upduser.Username= user.Username;
            upduser.Token= user.Token;
            upduser.Email= user.Email;

            await _context.SaveChangesAsync();

            return Ok(await _context.WebApiUsers.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<WebApiUser>>> Delete(int id)
        {
            var upduser = await _context.WebApiUsers.FindAsync(id);
            if (upduser == null)

                return BadRequest("User not found");
            _context.WebApiUsers.Remove(upduser);
             await _context.SaveChangesAsync();

            return Ok(await _context.WebApiUsers.ToListAsync());
        }

        //updating token by using username
        [HttpPut("attributes/{username}")]
        public async Task<IActionResult> UpdateToken([FromRoute] string username)
        {
            var webApiUsers = await _context.WebApiUsers.ToListAsync();
            var webApiUser = webApiUsers.Find(x => x.Username == username);
            webApiUser.Token = Guid.NewGuid().ToString();

            var id = webApiUser.Id.ToString();
            var cookie = new Cookie("AccountID", id);
            // Set the expiration time for the cookie
            cookie.Expires = DateTime.Now.AddDays(1);
            // Add the cookie to the response
            Response.Cookies.Append("AccountID", id, new CookieOptions { Expires = DateTime.Now.AddDays(1) });

            //            HttpContext.Session.SetString("AccountID", id);

            _context.Entry(webApiUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WebApiUsernameExists(username))
                {
                    return BadRequest("User not found");
                }
                else
                {
                    throw;
                }
            }

            return Ok(await _context.WebApiUsers.ToListAsync());
        }
        private bool WebApiUsernameExists(string username)
        {
            return _context.WebApiUsers.Any(e => e.Username == username);
        }
    }
}
