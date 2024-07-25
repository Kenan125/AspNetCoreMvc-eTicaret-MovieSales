namespace AspNetCoreMvc_eTicaret_MovieSales.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        //Nav Prop
        public List<MovieSale> MovieSales { get; set; }
    }
}
