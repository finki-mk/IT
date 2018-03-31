using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AudMVC1_1.Models;
namespace AudMVC1_1.Controllers
{
    public class MoviesController : Controller
    {
        Movie m= new Movie() { Name = "Shrek!", Rating = 4.8f, DownloadURL =@"nekoeURL"};
        static List<Client> lista = new List<Client>() {
                new Client() { Name = "Aleksandar Stojmenski", MovieCard = "1234",Address = "Partizanski Odredi 64",Telephone = "075444222",Age = 25},
                new Client() { Name = "Petko Petkovski", MovieCard = "5534",Address = "Ilindenska 16",Telephone = "02555333",Age = 17},
                new Client() { Name = "Trajko Trajkovski", MovieCard = "6666",Address = "Moskovska 12",Telephone = "02351144",Age = 21}
        };   
        // GET: Movies
        public ActionResult Random()
        {
            MovieRentals model = new MovieRentals();
            model.movie = m;
            model.customers = lista;
            return View(model);
        }
        public ActionResult ShowClient(int id)
        {
            Client model = lista.ElementAt(id);
            return View(model);
        }
    }
}