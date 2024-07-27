namespace AspNetCoreMvc_eTicaret_MovieSales.Entities
{
    public class MovieSaleDetail    //FilmSatışDetay
    {
        public int Id { get; set; }
        public int MovieSaleId { get; set; }
        public int MovieId { get; set; }
        public int Number { get; set; }
        public decimal UnitPrice { get; set; }

        //Navigation Property
        public MovieSale MovieSale { get; set; }
        public Movie Movie { get; set; }
    }
}
