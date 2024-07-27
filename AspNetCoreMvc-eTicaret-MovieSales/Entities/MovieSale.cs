namespace AspNetCoreMvc_eTicaret_MovieSales.Entities
{
    public class MovieSale      //FilmSatış
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int CustomerId { get; set; }
        public int TotalQuantity { get; set; }
        public decimal TotalPrice { get; set; }

        //Navigation Property
        public List<MovieSaleDetail> MovieSaleDetails { get; set; }
        public Customer Customer { get; set; }
    }
}
