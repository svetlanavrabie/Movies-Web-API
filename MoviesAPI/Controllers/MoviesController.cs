using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Dtos;
using MoviesAPI.Entities;
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

        private readonly IMapper _mapper;

        public MoviesController(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository ?? throw new ArgumentNullException(nameof(movieRepository));

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [MoviesResultFilter]
        public async Task<IActionResult> GetMovies()
        {
            var movies = await _movieRepository.GetMoviesAsyncr();

            return Ok(movies);
        }

        [HttpGet("{id}", Name = "GetMovie")]
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

        [HttpPost]
        [MovieResultFilter]
        public async Task<IActionResult> CreateMovie(MovieCreateDto movieCreateDto)
        {
            var movie = _mapper.Map<Movie>(movieCreateDto);

           _movieRepository.CreateMovie(movie);

            await _movieRepository.SaveChangesAsync();

            await _movieRepository.GetMovieAsyncr(movie.Id);

            return CreatedAtRoute("GetMovie", new { id=movie.Id}, movie);
        }
    }
}