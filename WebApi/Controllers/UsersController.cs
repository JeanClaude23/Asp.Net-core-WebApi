using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Net;

namespace WebApi.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class UsersController : ControllerBase
        {
            SqlConnection con = new SqlConnection("Data Source=192.168.8.4;Initial Catalog=MS_Learnings;User ID=ms_learning;Password=$Lsme123;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            [HttpPut("{username}")]
            public ActionResult UpdateToken([FromRoute]string username)
            {
            
                try
                {
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("select * from WebAPIUser where username='" + username + "'", con);
                    SqlDataReader sdr = cmd1.ExecuteReader();
                    if (sdr.Read())
                    {
                        var id = sdr["id"].ToString();
                        var cookie = new Cookie("AccountID", id);
                        // Set the expiration time for the cookie
                        cookie.Expires = DateTime.Now.AddDays(1);
                        // Add the cookie to the response
                        Response.Cookies.Append("AccountID", id, new CookieOptions { Expires = DateTime.Now.AddDays(1) });

                        //Session["key"] = "value";
                        HttpContext.Session.SetString("AccountID", id);
                    }
                

                    string token = Guid.NewGuid().ToString();
                    string qry = "update WebAPIUser set token = '"+token+"' where username='" + username+"'";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    int r  = cmd.ExecuteNonQuery();
                    if (r < 1)
                    {
                        return NotFound();
                    }
                    return Ok();
                
                }catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
                finally
                {
                    con.Close();
                }
                
                
            }

            [HttpGet]
            public string GetEmail(string username)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("select * from WebAPIUser where username='" + username + "'", con);
                    SqlDataReader sdr = cmd1.ExecuteReader();
                    if (sdr.Read())
                    {
                        return sdr["email"].ToString();
                    }
                    return "Not found";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                finally
                {
                    con.Close();
                }
            }

            [HttpPost]
            public void CreateToken(string username)
            {
            
        }
    }
}
