using AspNetCoreMvc_eTicaret_MovieSales.Entities;

namespace AspNetCoreMvc_eTicaret_MovieSales.Interfaces
{
    public interface IGenreRepository
    {
        public List<Genre> GetAll();
        public Genre Get(int id);

        public void Add(Genre genre);
        public void Update(Genre genre);
        public void Delete(int id);
        public void Delete(Genre genre);

    }
}
