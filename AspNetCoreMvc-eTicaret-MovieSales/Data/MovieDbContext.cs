using AspNetCoreMvc_eTicaret_MovieSales.Entities;
using Microsoft.EntityFrameworkCore;
using AspNetCoreMvc_eTicaret_MovieSales.ViewModels;

namespace AspNetCoreMvc_eTicaret_MovieSales.Data
{
    public class MovieDbContext : DbContext     //veritabanı
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options) { }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieSale> MovieSales { get; set; }
        public DbSet<MovieSaleDetail> MovieSaleDetails { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent API
            modelBuilder.Entity<Genre>().
                Property(g => g.Name).HasMaxLength(50);
            modelBuilder.Entity<Movie>().
                Property(m => m.Name).HasMaxLength(100);
            modelBuilder.Entity<Customer>().
                Property(c => c.Name).HasMaxLength(100);
            modelBuilder.Entity<Movie>().
                Property(m => m.IsPopuler).HasDefaultValue(true);
            modelBuilder.Entity<Movie>().
                Property(m => m.ImageUrl).HasDefaultValue("/images/filmadi.jpg");

            //Seed Data
            modelBuilder.Entity<Genre>().HasData(
                    new Genre() { Id = 1, Name = "Komedi", Description = "Komik olaylar"},
                    new Genre() { Id = 2, Name = "Savaş", Description = "Tarihi savaşlar" }, 
                    new Genre() { Id = 3, Name = "Romantik Komedi", Description = "Hem romantik hem komik" }, 
                    new Genre() { Id = 4, Name = "Dram", Description = "Acıklı hikayeler" }, 
                    new Genre() { Id = 5, Name = "Korku", Description = "Korku, gerilim" },
                    new Genre() { Id = 6, Name = "Bilim Kurgu", Description = "Uzay, robotlar" },
                    new Genre() { Id = 7, Name = "Fantastik", Description = "Gerçek dışı, heyecanlı" },
                    new Genre() { Id = 8, Name = "Aksiyon", Description = "Hareket, aksiyon sahneleri" }
                );
            modelBuilder.Entity<Movie>().HasData(
                    new Movie() { Id = 1, Name = "Truva", Director = "Wolfgan Pettersen", Cast = "Bradd Pitt, Orlando Bloom", Stock = 5, Price = 450, Summary = "Tarihi Truva savaşından kesitler", GenreId = 2},
                    new Movie() { Id = 2, Name = "Baskın", Director = "Gareth Evans", Cast = "Annda George, Donny Alamsyah", Stock = 6, Price = 400, Summary = "Operasyon timinin uyuşturucu baskınları", GenreId = 8 },
                    new Movie() { Id = 3, Name = "Titanic", Director = "James Cameron", Cast = "Leonardo Di Caprio, Cate Winslet", Stock = 15, Price = 500, Summary = "Lüks titanic gemisinin hazin öyküsü", GenreId = 4 },
                    new Movie() { Id = 4, Name = "Fight Club", Director = "David Lyinch", Cast = "Bradd Pitt, Edward Norton", Stock = 5, Price = 450, Summary = "Dövüş kulübü, ilk kural bahsetmemek", GenreId = 8 },
                    new Movie() { Id = 5, Name = "Soysuzlar Çetesi", Director = "Quantin Tarantino", Cast = "Bradd Pitt, Christoph Walls", Stock = 10, Price = 520, Summary = "2. Dünya savaşından kesitler", GenreId = 2 }
                );
            modelBuilder.Entity<Customer>().HasData(
                    new Customer() { Id = 1, Name = "Ali Uçar", Email = "aucar@gmail.com", Password = "123", Phone = "543 345 66 77", Address = "Beşiktaş-İstanbul"},
                    new Customer() { Id = 2, Name = "Oya Koşar", Email = "okosar@gmail.com", Password = "123", Phone = "533 345 66 77", Address = "Kadıköy-İstanbul" },
                    new Customer() { Id = 3, Name = "Neşe Sever", Email = "nsever@gmail.com", Password = "123", Phone = "542 345 66 77", Address = "Bakırköy-İstanbul" },
                    new Customer() { Id = 4, Name = "Hasan Kaya", Email = "hkaya@gmail.com", Password = "123", Phone = "535 345 66 77", Address = "Fatih-İstanbul" }
                );

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<AspNetCoreMvc_eTicaret_MovieSales.ViewModels.CustomerViewModel> CustomerViewModel { get; set; } = default!;
    }
}
