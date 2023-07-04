using bookDemo.Data;
using bookDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bookDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class booksController : ControllerBase
    {
        [HttpGet]
        public IActionResult getAllBooks()
        {
            var books = ApplicationContext.books;
            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public IActionResult getOneBook([FromRoute(Name ="id")]int id)
        {
            var book = ApplicationContext.books.Where(b=>b.Id == id).SingleOrDefault();
            if (book == null)
            {
                return NotFound(); 
            }
            return Ok(book);
        }

        [HttpPost]
        public IActionResult createOneBook([FromBody]book _book)
        {
            try
            {
                if(_book == null)
                {
                    return BadRequest();
                }
                ApplicationContext.books.Add(_book);
                return StatusCode(201, _book);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
