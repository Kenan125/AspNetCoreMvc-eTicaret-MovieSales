using AspNetCoreMvc_eTicaret_MovieSales.Entities;
using AspNetCoreMvc_eTicaret_MovieSales.Extensions;
using AspNetCoreMvc_eTicaret_MovieSales.Interfaces;
using AspNetCoreMvc_eTicaret_MovieSales.Models;
using AspNetCoreMvc_eTicaret_MovieSales.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvc_eTicaret_MovieSales.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepo;
        private readonly IMovieSaleRepository _movieSaleRepo;
        private readonly IMapper _mapper;

        List<CartItem> cart = new List<CartItem>();
        CartItem cartItem = new CartItem();
        public CustomerController(ICustomerRepository customerRepo, IMapper mapper, IMovieSaleRepository movieSaleRepo) //DI container
        {
            _customerRepo = customerRepo;
            _mapper = mapper;
            _movieSaleRepo = movieSaleRepo;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(CustomerLoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                var customer = _customerRepo.GetAll().FirstOrDefault(c => c.Email == model.Email && c.Password == model.Password);
                if (customer == null)
                {
                    ModelState.AddModelError("", "Hatalı email veya şifre girişi!");
                }
                else
                {
                    HttpContext.Session.SetJson("user", customer);  //login olan customer bilgilerini session'a kayıt ediyoruz.
                    return RedirectToAction("ConfirmAddress");
                }
            }
            return View(model);
        }
        public IActionResult ConfirmAddress() 
        {
            //Güvenlik için login olan kullanıcı bilgilerini session'dan çağırıp kontrol ediyoruz.
            var customer = HttpContext.Session.GetJson<Customer>("user");
            if (customer == null)
            {
                return RedirectToAction("Login");
            }
            return View(_mapper.Map<CustomerViewModel>(customer));
        }
        [HttpPost]
        public IActionResult ConfirmAddress(CustomerViewModel model)
        {
            _customerRepo.Update(_mapper.Map<Customer>(model)); //view'dan gelen kullanıcı bilgilerinin son halini veritabanına update ediyoruz.
            HttpContext.Session.SetJson("user", model); //Kullanıcının bilgileri değişmiş olabileceğinden son halini session'a kayıt ediyoruz.
            return RedirectToAction("ConfirmPayment");
        }
        public IActionResult ConfirmPayment()
        {
            var customer = HttpContext.Session.GetJson<Customer>("user");
            if (customer == null)
            {
                return RedirectToAction("Login");
            }
            //sepet bilgileri session'dan çekilecek
            cart = HttpContext.Session.GetJson<List<CartItem>>("sepet");
            int toplamAdet = cartItem.TotalQuantity(cart);
            decimal toplamTutar = cartItem.TotalPrice(cart);

            MovieSaleViewModel filmSatisViewModel = new MovieSaleViewModel();
            filmSatisViewModel.Date = DateTime.Now;
            filmSatisViewModel.CustomerId = customer.Id;
            filmSatisViewModel.TotalQuantity = toplamAdet;
            filmSatisViewModel.TotalPrice = toplamTutar;

            CustomerFaturaViewModel customerFaturaViewModel = new CustomerFaturaViewModel()
            {
                customerViewModel = _mapper.Map<CustomerViewModel>(customer),
                movieSaleViewModel = filmSatisViewModel,
                cartItems = cart
            };

            return View(customerFaturaViewModel);
        }
        [HttpPost]
        public IActionResult ConfirmPayment(CustomerFaturaViewModel model)
        {
            //MovieSale nesnesi veritabanına kayıt edilerek sql'in vereceği Id bilgisi elde edilecek.
            var satisId = _movieSaleRepo.AddSale(_mapper.Map<MovieSale>(model.movieSaleViewModel));

            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(CustomerViewModel model)
        {
            //view'dan gelen model bilgilerine göre yeni bir customer nesnesi veritabanına kayıt edilecek.
            return View();
        }
    }
}
