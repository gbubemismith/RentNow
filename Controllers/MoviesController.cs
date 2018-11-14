using RentNow.Models;
using RentNow.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace RentNow.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movies
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanMangeMovies))
            {
                return View("List");
            }
            else
            {
                return View("ReadOnlyList");
            }

            
            
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 

        [Authorize(Roles = RoleName.CanMangeMovies)]
        public ActionResult New()
        {
            var genre = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                
                Genre = genre
            };

            return View("MovieForm" , viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieFormViewModel(movie)
            {
                
                Genre = _context.Genres.ToList()

            };

            return View("MovieForm" , viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    
                    Genre = _context.Genres.ToList()
                };

                return View("MovieForm" , viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumberInStock = movie.NumberInStock;
            }

        

            _context.SaveChanges();


            return RedirectToAction("Index" , "Movies");
        }

      
    }
}