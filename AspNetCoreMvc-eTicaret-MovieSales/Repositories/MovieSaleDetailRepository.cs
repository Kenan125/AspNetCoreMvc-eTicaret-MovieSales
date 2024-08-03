using AspNetCoreMvc_eTicaret_MovieSales.Data;
using AspNetCoreMvc_eTicaret_MovieSales.Entities;
using AspNetCoreMvc_eTicaret_MovieSales.Interfaces;
using AspNetCoreMvc_eTicaret_MovieSales.Models;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace AspNetCoreMvc_eTicaret_MovieSales.Repositories
{
    public class MovieSaleDetailRepository : IMovieSaleDetailRepository
    {
        private readonly MovieDbContext _context;

        public MovieSaleDetailRepository(MovieDbContext context)
        {
            _context = context;
        }

        public List<MovieSaleDetail> GetAll()
        {
            return _context.MovieSaleDetails.ToList();
        }
        public MovieSaleDetail Get(int id)
        {
            return _context.MovieSaleDetails.Find(id);
        }
        
        public void Add(MovieSaleDetail movieSaleDetail)
        {
            _context.MovieSaleDetails.Add(movieSaleDetail);     //ara katmana ekler.
            _context.SaveChanges();         //veritabanına ekler.
        }

        public void Delete(int id)
        {
            _context.MovieSaleDetails.Remove(Get(id));    //Önce id'den nesneyi buluyor, ardından siliyor.
            _context.SaveChanges();             //veritabanından siler.
        }

        public void Delete(MovieSaleDetail movieSaleDetail)
        {
            _context.MovieSaleDetails.Remove(movieSaleDetail);      //Doğrudan nesneyi ara katmandan siliyor.
            _context.SaveChanges();
        }
        public void Update(MovieSaleDetail movieSaleDetail)
        {
            _context.MovieSaleDetails.Update(movieSaleDetail);      //Verilen nesneyi ara katmanda günceller.
            _context.SaveChanges();             //veritabanı güncellenir.
        }

        public bool AddRange(List<CartItem> sepet,int satisId)
        {
            foreach (var item in sepet)
            {
                MovieSaleDetail yeniSiparis = new MovieSaleDetail()
                {
                    MovieSaleId = satisId,
                    MovieId = item.MovieId,
                    Number = item.MovieQuantity,
                    UnitPrice = item.MoviePrice
                };
                _context.MovieSaleDetails.Add(yeniSiparis); // Ara katmana ekler
            }
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                string message = ex.Message;               
            }
            return false;
        }
    }
}
