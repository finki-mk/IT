using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AudMVC2_1.Models;
namespace AudMVC2_1.Controllers
{
    public class MoviesController : Controller
    {
        static List<Movie> moviesList = new List<Movie>()
        {
            new Movie() { Name = "Shrek!", Rating = 4.8f, DownloadURL =@"https://archive.org/details/Shrek.The.Halls.720p", ImgURL=@"https://vignette.wikia.nocookie.net/p__/images/c/ce/Shrek%27s_smile.jpeg/revision/latest?cb=20130711011930&path-prefix=protagonist"}
        };
        static List<Client> lista = new List<Client>() {
           };   
        // GET: Movies
        
        public ActionResult GetAllMovies()
        {
            return View(moviesList);
        }
        public ActionResult ShowMovie(int id)
        {
            var movie = moviesList.ElementAt(id);
            MovieRentals model = new MovieRentals();
            model.movie = movie;
            model.customers = lista;
            return View(model);
        }
        public ActionResult NewClient()
        {
            Client model = new Client();
            return View(model);
        }
        public ActionResult NewMovie()
        {
            Movie model = new Movie();
            return View(model);
        }
        [HttpPost]
        public ActionResult InsertNewClient(Client model)
        {
            if (!ModelState.IsValid)
            {
                return View("NewClient", model);

            }
            lista.Add(model);
            return View("GetAllMovies",moviesList);
        }
        [HttpPost]
        public ActionResult InsertNewMovie(Movie model)
        {
            if(!ModelState.IsValid)
            {
                return View("NewMovie",model);

            }
            moviesList.Add(model);
            return View("GetAllMovies", moviesList);
        }
        public ActionResult EditMovie(int id)
        {
            var model = moviesList.ElementAt(id);
            model.id = id;
            return View(model);
        }
        [HttpPost]
        public ActionResult EditMovie(Movie model)
        {
            if (!ModelState.IsValid)
            {
                return View("EditMovie", model);

            }
            var forUpdate = moviesList.ElementAt(model.id) ;
            forUpdate.ImgURL = model.ImgURL;
            forUpdate.Name = model.Name;
            forUpdate.DownloadURL = model.DownloadURL;
            forUpdate.Rating = model.Rating;
            return View("GetAllMovies", moviesList);
        }
        public ActionResult ShowClient(int id)
        {
            Client model = lista.ElementAt(id);
            return View(model);
        }
    }
}