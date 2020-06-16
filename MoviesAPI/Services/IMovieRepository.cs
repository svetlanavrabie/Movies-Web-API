using MoviesAPI.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesAPI.Services
{
    public interface IMovieRepository
    {
        public Task<IEnumerable<Movie>> GetMoviesAsyncr();

        public Task<IEnumerable<Movie>> GetMoviesAsyncr(IEnumerable<Guid> movieIds);

        public Task<Movie> GetMovieAsyncr(Guid id);

        public void CreateMovie(Movie movietoCreate);

        public Movie UpdateMovie(Movie movietoUpdate);

        public void DeleteMovie(Guid movieId);

        public Task<bool> SaveChangesAsync();
    }
}
