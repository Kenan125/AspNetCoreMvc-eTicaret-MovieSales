using AspNetCoreMvc_eTicaret_MovieSales.Entities;

namespace AspNetCoreMvc_eTicaret_MovieSales.Interfaces
{
    public interface IMovieSaleRepository
    {
        public List<MovieSale> GetAll();
        public MovieSale Get(int id);

        public int AddSale(MovieSale movieSale);
        public void Add(MovieSale movieSale);
        public void Update(MovieSale movieSale);
        public void Delete(int id);
        public void Delete(MovieSale movieSale);
    }
}
