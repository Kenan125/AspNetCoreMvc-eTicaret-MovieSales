using AspNetCoreMvc_eTicaret_MovieSales.Models;

namespace AspNetCoreMvc_eTicaret_MovieSales.ViewModels
{
    public class CustomerFaturaViewModel
    {
        public CustomerViewModel customerViewModel { get; set; }
        public MovieSaleViewModel movieSaleViewModel { get; set; }
        public List<CartItem> cartItems { get; set; }
    }
}
