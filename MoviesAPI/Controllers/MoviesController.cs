using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Filters;
using MoviesAPI.Services;
using System;
using System.Threading.Tasks;

namespace MoviesAPI.Controllers
{

    [ApiController]
    [Route("api/movies")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;

        public MoviesController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository ?? throw new ArgumentNullException(nameof(movieRepository));
        }

        [HttpGet]
        [MoviesResultFilter]
        public async Task<IActionResult> GetMovies()
        {
            var movies = await _movieRepository.GetMoviesAsyncr();

            return Ok(movies);
        }

        [HttpGet("{id}")]
        [MovieResultFilter]
        public async Task<IActionResult> GetMovie(Guid id)
        {
            var movie = await _movieRepository.GetMovieAsyncr(id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }
    }
}