using AudMVC4_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AudMVC4_1.Controllers
{
    public class ClientsController : Controller
    {
        private MoviesDbContext _context;
        public ClientsController()
        {
            _context = new MoviesDbContext();
        }
        // GET: Clients
        public ActionResult Index()
        {
            _context = new MoviesDbContext();
            return View();
        }
        public ActionResult ShowClient(int id)
        {
            Client model = _context.Clients.FirstOrDefault(z => z.Id == id);
            return View(model);
        }
        public ActionResult NewClient()
        {
            Client model = new Client();
            return View(model);
        }
        public ActionResult InsertClientMovie(int id)
        {
            var model = new ClientMovie();
            model.movie = _context.Movies.FirstOrDefault(z => z.id == id);
            model.movieId = id;
            model.clients = _context.Clients.ToList() ;
            return View(model);
        }
        [HttpPost]
        public ActionResult InsertClientMovie(ClientMovie model)
        {
            _context.Movies.FirstOrDefault(z =>z.id==model.movieId).clients.Add(_context.Clients.FirstOrDefault(z =>z.Id==model.selectedClientId));
            _context.SaveChanges();
            return RedirectToAction("ShowMovie","Movies",new { id = model.movieId});
        }
        [HttpPost]
        public ActionResult InsertNewClient(Client model)
        {
            if (!ModelState.IsValid)
            {
                return View("NewClient", model);

            }
            _context.Clients.Add(model);
            _context.SaveChanges();
            return RedirectToAction("GetAllMovies","Movies", _context.Movies.ToList());
        }
    }
}