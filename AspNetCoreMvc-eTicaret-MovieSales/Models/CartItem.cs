namespace AspNetCoreMvc_eTicaret_MovieSales.Models
{
    public class CartItem
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public int MovieQuantity { get; set; }
        public decimal MoviePrice { get; set; }

        public List<CartItem> AddToCart(List<CartItem> cart, CartItem cartItem)
        {
            //if(cart.Any(c => c.MovieId == cartItem.MovieId)) {  sipariş sepette varsa true döner.
            //    //ürünü bulup adet artırılacak.
            //}
            var item = cart.Find(c => c.MovieId == cartItem.MovieId);  //sepette yeni siparişle aynı üründen varsa yakalar.
            if(item != null)
            {
                item.MovieQuantity += cartItem.MovieQuantity;  //aynı ürünü bulup miktarını yeni siparişin miktarı kadar artırıyoruz.
            }
            else
            {
                cart.Add(cartItem);         //siparişi sepete ekler.
            }
            return cart;  
        }
        public List<CartItem> DeleteFromCart(List<CartItem> cart, int id)
        {
            cart.RemoveAll(c => c.MovieId == id);
            return cart;
        }
        public int TotalQuantity(List<CartItem> cart)
        {
            int total = cart.Sum(c => c.MovieQuantity);
            return total;
        }
        public decimal TotalPrice(List<CartItem> cart)
        {
            decimal total = cart.Sum(c => c.MovieQuantity * c.MoviePrice);
            return total;
        }
    }
}
