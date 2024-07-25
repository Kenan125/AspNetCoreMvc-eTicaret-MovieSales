using AspNetCoreMvc_eTicaret_MovieSales.Data;
using AspNetCoreMvc_eTicaret_MovieSales.Entities;
using AspNetCoreMvc_eTicaret_MovieSales.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMvc_eTicaret_MovieSales.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDbContext _context;

        public MovieRepository(MovieDbContext context)
        {
            _context = context;
        }
        public List<Movie> GetAll()
        {
            return _context.Movies.ToList();
        }
        public Movie Get(int id)
        {
            return _context.Movies.Find(id);
        }

        public void Add(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Movies.Remove(Get(id));
            _context.SaveChanges();
        }

        public void DeleteAll(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }

        public void Update(Movie movie)
        {
            _context.Movies.Update(movie);
            _context.SaveChanges();
        }
    }
}
