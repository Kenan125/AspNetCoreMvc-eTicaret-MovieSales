using AspNetCoreMvc_eTicaret_MovieSales.Extensions;
using AspNetCoreMvc_eTicaret_MovieSales.Interfaces;
using AspNetCoreMvc_eTicaret_MovieSales.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvc_eTicaret_MovieSales.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepo;


        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(CustomerLoginViewModel model) 
        {
            if (ModelState.IsValid)
            {
                var customer = _customerRepo.GetAll().FirstOrDefault(c=>c.Email==model.Email && c.Password == model.Password);
                if (customer==null)
                {
                    ModelState.AddModelError("", "Hatalı email veyaşifre girişi!");
                }
                else
                {
                    HttpContext.Session.SetJson("user", customer);
                    return RedirectToAction("ConfirmAddress");
                }

            }
            return View(model);


        }
        public IActionResult ConfirmAddress()
        {
            return View();
        }

    }
}
