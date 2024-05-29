using BookStoreAPI.Models;
using BookStoreAPI.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStoreAPI.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        // GET: api/<BookController>
        [HttpGet]
        public IActionResult Get()
        {

            var books = _bookRepository.GetAllBooks();
            return Ok(books);
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var book = _bookRepository.GetBookById(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // POST api/<BookController>
        [HttpPost]
        public void Post([FromBody] BookDTO book)
        {
            _bookRepository.AddBook(book);
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] BookDTO book)
        {
            // Edit a specific book by its ID from the BookStore
            _bookRepository.UpdateBook(book, id);

        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // Delete a specific book by its ID from the BookStore
            _bookRepository.DeleteBook(id);
        }
    }
}
