using AspNetCoreMvc_eTicaret_MovieSales.Extensions;
using AspNetCoreMvc_eTicaret_MovieSales.Interfaces;
using AspNetCoreMvc_eTicaret_MovieSales.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvc_eTicaret_MovieSales.Controllers
{
    public class CartController : Controller
    {
        private readonly IMovieRepository _movieRepo;

        public CartController(IMovieRepository movieRepo)
        {
            _movieRepo = movieRepo;
        }

        List<CartItem> cart = new List<CartItem>();   //sepet
        CartItem cartItem = new CartItem();           //siparis
        public IActionResult Index()
        {
            cart = GetCart();  //Session'dan sepeti alıyoruz.
            TempData["ToplamAdet"] = cartItem.TotalQuantity(cart);
            if (cartItem.TotalPrice(cart) > 0)
                TempData["ToplamTutar"] = cartItem.TotalPrice(cart);
            return View(cart);
        }
        public IActionResult Add(int id, int Adet) 
        {
            var movie = _movieRepo.Get(id); //siparis edilecek movie
            cart = GetCart();               //sepetimi istiyorum (ilk olarak bos sepet)
            cartItem.MovieId = movie.Id;    //siparis olusturuyoruz
            cartItem.MovieName = movie.Name;
            cartItem.MovieQuantity = Adet;
            cartItem.MoviePrice=movie.Price;
            cartItem.AddToCart(cart, cartItem);
            SetCart(cart);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id) 
        {
            var movie =_movieRepo.Get(id);
            cart = GetCart();
            cart = cartItem.DeleteFromCart(cart,id);

            SetCart(cart);
            
            return RedirectToAction("Index");
        
        }
        public void SetCart(List<CartItem> sepet) //sepet kayit (json formatta)
        {
            HttpContext.Session.SetJson("sepet", sepet);
        }
        public List<CartItem> GetCart() //kayitli sepeti  getir. (text formatta)
        {
            var sepet = HttpContext.Session.GetJson<List<CartItem>>("sepet") ?? new List<CartItem>();
            //ilk basta sepet olmadigindan sepet null gelir bize bos sepet dondurur
            return sepet;
        }
        public IActionResult DeleteCart()
        {
            HttpContext.Session.Remove("sepet"); //Oturumda bulunan tum sessionlari siler. \_o.o_/
            return RedirectToAction("Index");
        }                                                          
    }
}
