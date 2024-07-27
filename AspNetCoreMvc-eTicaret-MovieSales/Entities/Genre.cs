namespace AspNetCoreMvc_eTicaret_MovieSales.Entities
{
    public class Genre    //Film Türü
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        //Navigation Property
        public List<Movie> Movies { get; set; }
    }
}
