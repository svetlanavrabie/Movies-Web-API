using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Dtos;
using MoviesAPI.Entities;
using MoviesAPI.Filters;
using MoviesAPI.ModelBinders;
using MoviesAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Controllers
{

    [ApiController]
    [Route("api/moviescollections")]
    [MoviesResultFilter]
    public class MoviesCollectionsController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;

        private readonly IMapper _mapper;

        public MoviesCollectionsController(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository ?? throw new ArgumentNullException(nameof(movieRepository));

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("({movieIds})", Name = "GetMoviesCollection")]
        public async Task<IActionResult> GetMoviesCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> movieIds)
        {
            var movies = await _movieRepository.GetMoviesAsyncr(movieIds);

            if (movieIds.Count() != movies.Count())
            {
                return NotFound();
            }
            return Ok(movies);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMoviesCollections(IEnumerable<MovieCreateDto> moviesCollection)
        {
            var movies = _mapper.Map<IEnumerable<Movie>>(moviesCollection);

            foreach (var movie in movies)
            {
                _movieRepository.CreateMovie(movie);
            }

            await _movieRepository.SaveChangesAsync();

            var moviesToReturn = await _movieRepository.GetMoviesAsyncr(movies.Select(m => m.Id).ToList());

            var movieIds = string.Join(",", moviesToReturn.Select(a => a.Id));

            return CreatedAtRoute("GetMoviesCollection", new { movieIds }, moviesToReturn);
        }
    }
}