using Microsoft.EntityFrameworkCore;
using MoviesAPI.Contexts;
using MoviesAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Services
{
    public class MovieRepository : IMovieRepository, IDisposable
    {
        private MoviesContext _context;

        public MovieRepository(MoviesContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Movie> GetMovieAsyncr(Guid id)
        {
            return await _context.Movies.Include(d => d.Director).FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Movie>> GetMoviesAsyncr()
        {
            await _context.Database.ExecuteSqlRawAsync("WAITFOR DELAY '00:00:02'");
            return await _context.Movies.Include(d => d.Director).ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetMoviesAsyncr(IEnumerable<Guid> movieIds)
        {
            return await _context.Movies.Where(m => movieIds.Contains(m.Id)).Include(m => m.Director).ToListAsync();
        }

        public void CreateMovie(Movie movietoCreate)
        {
            if (movietoCreate == null)
            {
                throw new ArgumentNullException(nameof(movietoCreate));
            }
            _context.Add(movietoCreate);
        }

        public Movie UpdateMovie(Movie movietoUpdate)
        {
            if (movietoUpdate == null)
            {
                throw new ArgumentNullException(nameof(movietoUpdate));
            }
            _context.Update(movietoUpdate);

            return movietoUpdate;
        }

        public void DeleteMovie(Guid movieId)
        {
            var movie = _context.Movies.Find(movieId);

            _context.Remove(movie);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;

                }
            }
        }
    }
}
