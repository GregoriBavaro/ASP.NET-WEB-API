using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeWorkApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<string>> GetAllUserNames()
        {
            return Ok(StaticDb.UserNames);
        }

        [HttpGet("user/{userId}")]
        public ActionResult<string> GetUserById(int userId)
        {
            try
            {
                if (userId < 0)
                {
                    return BadRequest("Invalid user ID. The user id cant be negative");

                }

                if (userId >= StaticDb.UserNames.Count)
                {
                    return BadRequest($"The user with {userId} does not exist");
                }

                return Ok($"User Name: {StaticDb.UserNames[userId]}, User ID: {userId}");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred. Contact the administrator");
            }
        }

        [HttpPost("Add")]
        public IActionResult Post()
        {
            try
            {
                using (StreamReader reader = new StreamReader(Request.Body))
                {
                    string newUser = reader.ReadToEnd();

                    if (string.IsNullOrEmpty(newUser))
                    {
                        return BadRequest("The body of the request can not be empty");
                    }
                    StaticDb.UserNames.Add(newUser);

                    return StatusCode(StatusCodes.Status201Created, "A new user was added");

                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred. Contact the administrator");
            }
        }
    }
}
