namespace AspNetCoreMvc_eTicaret_MovieSales.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Director { get; set; }
        public string? Cast { get; set; }
        public string? Summary { get; set; }
        public DateTime ReleaseDate { get; set; } = DateTime.Now;
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsLocal { get; set; } //Yerli-Yabanci
        public bool IsPopular { get; set; }
        public int GenreId { get; set; }

        //Navigation Property(Relations)
        public Genre Genre { get; set; }
        public List<MovieSaleDetail> MovieSaleDetails { get; set; }
    }
}
