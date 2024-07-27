using AspNetCoreMvc_eTicaret_MovieSales.Data;
using AspNetCoreMvc_eTicaret_MovieSales.Entities;
using AspNetCoreMvc_eTicaret_MovieSales.Interfaces;

namespace AspNetCoreMvc_eTicaret_MovieSales.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly MovieDbContext _context;

        public GenreRepository(MovieDbContext context)   //DI Container'dan nesne istiyoruz.
        {
            _context = context;
        }
        public List<Genre> GetAll()
        {
            return _context.Genres.ToList();
        }
        public Genre Get(int id)
        {
            return _context.Genres.Find(id);
        }
        public void Add(Genre genre)
        {
            _context.Genres.Add(genre);     //ara katmana ekler.
            _context.SaveChanges();         //veritabanına ekler.
        }

        public void Delete(int id)
        {
            _context.Genres.Remove(Get(id));    //Önce id'den nesneyi buluyor, ardından siliyor.
            _context.SaveChanges();             //veritabanından siler.
        }

        public void Delete(Genre genre)
        {
            _context.Genres.Remove(genre);      //Doğrudan nesneyi ara katmandan siliyor.
            _context.SaveChanges();
        }
        public void Update(Genre genre)
        {
            _context.Genres.Update(genre);      //Verilen nesneyi ara katmanda günceller.
            _context.SaveChanges();             //veritabanı güncellenir.
        }
    }
}
