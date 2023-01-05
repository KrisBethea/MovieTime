using Interfaces;
using Microsoft.AspNetCore.Mvc;
using MovieTime.Models;
using Services;
using System.Diagnostics;

namespace MovieTime.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFilmService _filmService;

        public HomeController(ILogger<HomeController> logger, IFilmService FilmService)
        {
            _logger = logger;
            _filmService = FilmService;
        }

        public IActionResult Index()
        {
           var model = GetFilms();
            // return  model == null ? null : View(model);
            if (model == null)
                return Content("model is not availble");
            return View(model);
            //return View();
        }

        // GET: api/Films
        [HttpGet]
        public IEnumerable<Films> GetFilms()
        {         

            return  _filmService.GetFilms();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}