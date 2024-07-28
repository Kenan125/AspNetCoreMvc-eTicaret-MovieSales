namespace AspNetCoreMvc_eTicaret_MovieSales.Models
{
    public class CartItem
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public int MovieQuantity { get; set; }
        public decimal MoviePrice { get; set; }

        public List<CartItem> AddToCart(List<CartItem> cart,CartItem cartItem)
        {
            //if(cart.Any(c=>c.MovieId == cartItem.MovieId))
            var item = cart.Find(c=>c.MovieId == cartItem.MovieId);
            if (item != null)
            {
                item.MovieQuantity += cartItem.MovieQuantity;
            }
            else 
            {
                cart.Add(cartItem);
            }
            return cart;
        }
        public List<CartItem> DeleteFromCart(List<CartItem> cart, int id) 
        { 
            cart.RemoveAll(c=>c.MovieId == id);
            return cart;
        }
        public int TotalQuantity(List<CartItem> cart) 
        {
            int total = cart.Sum(c=>c.MovieQuantity);
            return total;
        }
        public decimal TotalPrice(List<CartItem> cart) 
        {
            decimal total = cart.Sum(c => c.MovieQuantity*c.MoviePrice);
            return total;
        }

    }
}
