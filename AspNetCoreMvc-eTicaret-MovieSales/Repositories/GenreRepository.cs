using AspNetCoreMvc_eTicaret_MovieSales.Data;
using AspNetCoreMvc_eTicaret_MovieSales.Entities;
using AspNetCoreMvc_eTicaret_MovieSales.Interfaces;

namespace AspNetCoreMvc_eTicaret_MovieSales.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly MovieDbContext _context;

        public GenreRepository(MovieDbContext context)
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
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Genres.Remove(Get(id));
            _context.SaveChanges();
        }

        public void DeleteAll(Genre genre)
        {
            _context.Genres.Remove(genre);
            _context.SaveChanges();
        }

        public void Update(Genre genre)
        {
            _context.Genres.Update(genre);
            _context.SaveChanges();
        }
    }
}
