using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AudMVC3_1.Models;
namespace AudMVC3_1.Controllers
{
    public class MoviesController : Controller
    {
        private MoviesDbContext _context;
        public MoviesController()
        {
            _context = new MoviesDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult GetAllMovies()
        {
            return View(_context.Movies.ToList());
        }
        public ActionResult ShowMovie(int id)
        {
            var movie = _context.Movies.FirstOrDefault(z =>z.id==id);
            MovieRentals model = new MovieRentals();
            model.movie = movie;
            model.customers = movie.clients.ToList();
            return View(model);
        }
        public ActionResult NewMovie()
        {
            Movie model = new Movie();
            return View(model);
        }
    
        [HttpPost]
        public ActionResult InsertNewMovie(Movie model)
        {
                if (!ModelState.IsValid)
                {
                    return View("NewMovie", model);

                }
                _context.Movies.Add(model);
                _context.SaveChanges();
                return View("GetAllMovies", _context.Movies.ToList());
        }
        public ActionResult EditMovie(int id)
        {
            var model = _context.Movies.FirstOrDefault(z => z.id == id);
            model.id = id;
            return View(model);
        }
        public ActionResult DeleteMovie(int id)
        {
            _context.Movies.Remove(_context.Movies.FirstOrDefault(z => z.id == id));
            _context.SaveChanges();
            return View("GetAllMovies", _context.Movies.ToList());
        }
        [HttpPost]
        public ActionResult EditMovie(Movie model)
        {
            if (!ModelState.IsValid)
            {
                return View("EditMovie", model);

            }
            var forUpdate = _context.Movies.FirstOrDefault(z => z.id == model.id);
            forUpdate.ImgURL = model.ImgURL;
            forUpdate.Name = model.Name;
            forUpdate.DownloadURL = model.DownloadURL;
            forUpdate.Rating = model.Rating;
            _context.SaveChanges();
            return View("GetAllMovies", _context.Movies.ToList());
        }
    }
}