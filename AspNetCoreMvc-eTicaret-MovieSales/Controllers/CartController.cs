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
            return View();
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
    }
}
