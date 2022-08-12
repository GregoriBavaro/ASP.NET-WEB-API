using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEDC.BookLibreryApp.Modals;

namespace SEDC.BookLibreryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Books : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Book>> Get()
        {
            try
            {
                return Ok(StaticDb.Books);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred! Contact the admin!");
            }
        }

        [HttpGet("getBookByIndex")]
        public ActionResult<Book> GetBookByIndex(int? index)
        {
            try
            {
                if (index < 0)
                {
                    return BadRequest("The index can not be negative");
                }

                if (index == null)
                {
                    return BadRequest("Index is a required parameter");
                }

                if (index >= StaticDb.Books.Count)
                {
                    return NotFound($"There is no resource of index {index}");
                }

                return Ok(StaticDb.Books[index.Value]);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred! Contact the admin!");
            }
        }

        [HttpGet("filterBooks")]
        public ActionResult<Book> FilterBooks(string author, string title)
        {
            try
            {
                if (string.IsNullOrEmpty(author) || string.IsNullOrEmpty(title))
                {
                    return BadRequest("Filter parameters are required");
                }

                List<Book> booksDb = StaticDb.Books.Where(x => x.Title.ToLower().Contains(title.ToLower()) && x.Author.ToLower().Contains(author.ToLower())).ToList();
                return Ok(booksDb);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred! Contact the admin!");
            }
        }

        [HttpPost]
        public IActionResult PostBook([FromBody] Book book)
        {
            try
            {
                if (string.IsNullOrEmpty(book.Author) || string.IsNullOrEmpty(book.Title))
                {
                    return BadRequest("Book properties must be filled");
                }

                StaticDb.Books.Add(book);
                return StatusCode(StatusCodes.Status201Created, "Book added");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred! Contact the admin!");
            }
        }
    }
}
