using AspNetCoreMvc_eTicaret_MovieSales.Data;
using AspNetCoreMvc_eTicaret_MovieSales.Entities;
using AspNetCoreMvc_eTicaret_MovieSales.Interfaces;

namespace AspNetCoreMvc_eTicaret_MovieSales.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDbContext _context;

        public MovieRepository(MovieDbContext context)   //DI Container'dan nesne istiyoruz.
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
            _context.Movies.Add(movie);     //ara katmana ekler.
            _context.SaveChanges();         //veritabanına ekler.
        }
        public void Delete(int id)
        {
            _context.Movies.Remove(Get(id));    //Önce id'den nesneyi buluyor, ardından siliyor.
            _context.SaveChanges();             //veritabanından siler.
        }
        public void Delete(Movie movie)
        {
            _context.Movies.Remove(movie);      //Doğrudan nesneyi ara katmandan siliyor.
            _context.SaveChanges();
        }
        public void Update(Movie movie)
        {
            _context.Movies.Update(movie);      //Verilen nesneyi ara katmanda günceller.
            _context.SaveChanges();             //veritabanı güncellenir.
        }
    }
}
