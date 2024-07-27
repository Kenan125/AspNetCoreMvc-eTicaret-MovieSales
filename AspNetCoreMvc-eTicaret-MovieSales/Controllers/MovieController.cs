using AspNetCoreMvc_eTicaret_MovieSales.Entities;
using AspNetCoreMvc_eTicaret_MovieSales.Interfaces;
using AspNetCoreMvc_eTicaret_MovieSales.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Text;

namespace AspNetCoreMvc_eTicaret_MovieSales.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository _movieRepo;
        private readonly IMapper _mapper;

        public MovieController(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepo = movieRepository;
            _mapper = mapper;
        }

        public IActionResult Index(int? id, string? search) 
        {
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
            var movies = _movieRepo.GetAll().Where(m=>m.IsPopuler == true).ToList();
            return View(_mapper.Map<List<MovieViewModel>>(movies));
        }

        public IActionResult Local(bool isLocal) 
        {
            var movies = _movieRepo.GetAll();
            if (isLocal)
            {
                movies = _movieRepo.GetAll().Where(m => m.IsLocal == true).ToList();
                ViewBag.Local = "Yerli";
                
            }
            else 
            {
                movies = _movieRepo.GetAll().Where(m => m.IsLocal == false).ToList();
                ViewBag.Local = "Yabancı";

                
            }
            return View(_mapper.Map<List<MovieViewModel>>(movies));
        }
        public IActionResult Details(int id) 
        {
            var movies = _movieRepo.Get(id);
            return View(_mapper.Map<MovieViewModel>(movies));
        }
        
    }
}
