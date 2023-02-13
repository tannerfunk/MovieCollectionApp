using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieCollectionApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollectionApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieSubmissionContext movieContext { get; set; }

        // Constructor
        public HomeController(ILogger<HomeController> logger, MovieSubmissionContext someName)
        {
            _logger = logger;
            movieContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult InputMovie ()
        {
            return View("InputMovieComponent");
        }

        [HttpPost]
        public IActionResult InputMovie (MovieInput mi)
        {
            if (ModelState.IsValid)
            {
                movieContext.Add(mi);
                movieContext.SaveChanges();

                return View("Confirmation", mi);
            }
            return View("InputMovieComponent");

        }

        [HttpGet]
        public IActionResult Podcast()
        {
            return View("PodcastTown");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
