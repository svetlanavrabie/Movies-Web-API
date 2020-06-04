using MoviesAPI.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesAPI.Services
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetMoviesAsyncr();

        Task<Movie> GetMovieAsyncr(Guid id);
    }
}
