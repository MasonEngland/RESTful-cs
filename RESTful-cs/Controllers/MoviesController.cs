using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RESTful_cs.Context;
using RESTful_cs.Models;

namespace RESTful_cs.Controllers
{
    [Route("/[controller]")]
    public class MoviesController : Controller
    {

        //private static List<string> database = new() { "Shrek", "Milo & Otis", "Mario" };
        private readonly DatabaseContext _db;

        public MoviesController(DatabaseContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetMovie() // returns all movies in the database
        {
            try
            {
                List<Movie> movies = _db.Movies.ToList();
                Debug.WriteLine(movies);
                return Ok(movies);
            } catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return StatusCode(500);
            }
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] Movie movie)
        {
            try
            {
                // get all data from database and check if names match
                Debug.WriteLine(movie.Name);
                List<Movie> selectedMovies = _db.Movies.ToList();


                foreach (Movie item in selectedMovies)
                {
                    if (movie.Name.ToLower() == item.Name.ToLower())
                    {
                        return BadRequest("Movie already Registered");
                    }
                }


                // Save docs to database
                _db.Movies.Add(movie);
                _db.SaveChanges();
                return Ok(movie);
            } catch (Exception err) //catches all error types
            {
                Debug.WriteLine(err.Message);
                return StatusCode(500);

            }
        }
    }
}

