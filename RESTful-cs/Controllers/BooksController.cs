using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RESTful_cs.Context;
using RESTful_cs.Models;

namespace RESTful_cs.Controllers
{
    [Route("/[controller]")]
    public class BooksController: Controller
	{
        private readonly DatabaseContext _db;

        public BooksController(DatabaseContext db)
        {
            _db = db;
        }

        // GET: /Books
        [HttpGet]
        public IActionResult GetBooks()
        {
            try
            {
                // pull books from the database
                List<Book> books = _db.Books.ToList();
                return Ok(books);

            } catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return StatusCode(500);
            }
        }

        // POST: /Books
        [HttpPost]
        public IActionResult RegisterBook([FromBody] Book book)
        {
            try { 
                // get all data from Books Table
                List<Book> RegisteredBooks = _db.Books.ToList();

                // check if book is already registered
                foreach (var item in RegisteredBooks)
                {
                    if (book.Name == item.Name)
                    {
                        return BadRequest("Book already Registered");
                    }
                }
                //save data to database
                _db.Books.Add(book);
                _db.SaveChanges();
                return Ok(book);


            } catch (Exception err)
            {
                //Error handling
                Debug.WriteLine(err.Message);
                return StatusCode(500);
            }
        }
	}
}

