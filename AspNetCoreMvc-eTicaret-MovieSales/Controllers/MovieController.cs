using AspNetCoreMvc_eTicaret_MovieSales.Extensions;
using AspNetCoreMvc_eTicaret_MovieSales.Interfaces;
using AspNetCoreMvc_eTicaret_MovieSales.Models;
using AspNetCoreMvc_eTicaret_MovieSales.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvc_eTicaret_MovieSales.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository _movieRepo;
        private readonly IMapper _mapper;

        List<CartItem> cart = new List<CartItem>();     //sepet
        CartItem cartItem = new CartItem();             //sipariş
        public MovieController(IMovieRepository movieRepo, IMapper mapper)
        {
            _movieRepo = movieRepo;
            _mapper = mapper;
        }
        public IActionResult Index(int? id, string? search)      //id -> genreId
        {
            cart = HttpContext.Session.GetJson<List<CartItem>>("sepet") ?? new List<CartItem>();
            TempData["ToplamAdet"] = cartItem.TotalQuantity(cart);
            var movies = _movieRepo.GetAll();

            if (search != null)
            {
                movies = movies.Where(m => m.Name.ToLower().Contains(search.ToLower())).ToList();
            }

            if (id != null)
            {
                movies = movies.Where(m => m.GenreId == id).ToList();
            }

            return View(_mapper.Map<List<MovieViewModel>>(movies));
        }

        public IActionResult Populer() 
        {
            cart = HttpContext.Session.GetJson<List<CartItem>>("sepet") ?? new List<CartItem>();
            TempData["ToplamAdet"] = cartItem.TotalQuantity(cart);
            var movies = _movieRepo.GetAll().Where(m => m.IsPopuler == true).ToList();

            return View(_mapper.Map<List<MovieViewModel>>(movies));
        }
        public IActionResult Local(bool isLocal)    //true-Yerli, false-Yabancı Filmler
        {
            cart = HttpContext.Session.GetJson<List<CartItem>>("sepet") ?? new List<CartItem>();
            TempData["ToplamAdet"] = cartItem.TotalQuantity(cart);
            var movies = _movieRepo.GetAll();

            if(isLocal == true)
            {
                movies = movies.Where(m => m.IsLocal == true).ToList();  //Yerli Filmler
                ViewBag.Local = "Yerli";
            }
            else
            {
                movies = movies.Where(m => m.IsLocal == false).ToList();  //Yabancı Filmler
                ViewBag.Local = "Yabancı";
            }
            return View(_mapper.Map<List<MovieViewModel>>(movies));
        }
        public IActionResult Details(int id)    //id -> movie.Id
        {
            //Seçilen film bulunacak. Details view sayfasına MovieViewModel olarak gönderilecek.
            var movie = _movieRepo.Get(id);
            return View(_mapper.Map<MovieViewModel>(movie));
        }
    }
}
