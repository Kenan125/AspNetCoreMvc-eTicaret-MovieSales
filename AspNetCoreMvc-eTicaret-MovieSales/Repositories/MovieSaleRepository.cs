using AspNetCoreMvc_eTicaret_MovieSales.Data;
using AspNetCoreMvc_eTicaret_MovieSales.Entities;
using AspNetCoreMvc_eTicaret_MovieSales.Interfaces;

namespace AspNetCoreMvc_eTicaret_MovieSales.Repositories
{
    public class MovieSaleRepository : IMovieSaleRepository
    {
        private readonly MovieDbContext _context;

        public MovieSaleRepository(MovieDbContext context)   //DI Container'dan nesne istiyoruz.
        {
            _context = context;
        }
        public List<MovieSale> GetAll()
        {
            return _context.MovieSales.ToList();
        }
        public MovieSale Get(int id)
        {
            return _context.MovieSales.Find(id);
        }
        public int AddSale(MovieSale movieSale)
        {
            _context.MovieSales.Add(movieSale);     //ara katmana ekler.
            _context.SaveChanges();         //veritabanına ekler ve sql id değerini atar.
            return movieSale.Id;
        }
        public void Add(MovieSale movieSale)
        {
            _context.MovieSales.Add(movieSale);     //ara katmana ekler.
            _context.SaveChanges();         //veritabanına ekler.
        }

        public void Delete(int id)
        {
            _context.MovieSales.Remove(Get(id));    //Önce id'den nesneyi buluyor, ardından siliyor.
            _context.SaveChanges();             //veritabanından siler.
        }

        public void Delete(MovieSale movieSale)
        {
            _context.MovieSales.Remove(movieSale);      //Doğrudan nesneyi ara katmandan siliyor.
            _context.SaveChanges();
        }
        public void Update(MovieSale movieSale)
        {
            _context.MovieSales.Update(movieSale);      //Verilen nesneyi ara katmanda günceller.
            _context.SaveChanges();             //veritabanı güncellenir.
        }
    }
}
