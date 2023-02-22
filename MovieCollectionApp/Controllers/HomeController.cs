using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private MovieSubmissionContext movieContext { get; set; }

        // Constructor
        public HomeController(MovieSubmissionContext someName)
        {
            movieContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult InputMovie ()
        {
            ViewBag.Categories = movieContext.Category.ToList();

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
            ViewBag.Categories = movieContext.Category.ToList();
            return View("InputMovieComponent", mi);

        }

        [HttpGet]
        public IActionResult Podcast()
        {
            return View("PodcastTown");
        }

        [HttpGet]
        public IActionResult MovieList ()
        {
            var entries = movieContext.Inputs
                .Include(x => x.Category)
                //.Where(x => x.Year > 2010) THIS FILTERS
                .OrderBy(x => x.Title)
                .ToList();

            return View(entries);
        }

        [HttpGet]
        public IActionResult Edit (int movieid)
        {
            ViewBag.Categories = movieContext.Category.ToList();

            var entry = movieContext.Inputs.Single(x => x.MovieId == movieid);

            return View("InputMovieComponent", entry);
        }

        [HttpPost]
        public IActionResult Edit (MovieInput miupdate)
        {
            movieContext.Update(miupdate);
            movieContext.SaveChanges();

            // this is so that it doesn't JUST go to the view, but it does the same thing as before.
            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var entry = movieContext.Inputs.Single(x => x.MovieId == movieid);

            return View(entry);
        }

        [HttpPost]
        public IActionResult Delete(MovieInput mi)
        {
            movieContext.Inputs.Remove(mi);
            movieContext.SaveChanges();
            return RedirectToAction("MovieList");
        }
    }
}
