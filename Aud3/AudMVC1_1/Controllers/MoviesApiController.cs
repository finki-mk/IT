using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AudMVC3_1.Models;

namespace AudMVC1_1.Controllers
{
    public class MoviesApiController : ApiController
    {
        private MoviesDbContext db = new MoviesDbContext();

        // GET: api/MoviesApi
        public IQueryable<Movie> GetMovies()
        {
            return db.Movies;
        }

        // GET: api/MoviesApi/5
        [ResponseType(typeof(Movie))]
        public IHttpActionResult GetMovie(int id)
        {
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        // PUT: api/MoviesApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMovie(int id, Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != movie.id)
            {
                return BadRequest();
            }

            db.Entry(movie).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/MoviesApi
        [ResponseType(typeof(Movie))]
        public IHttpActionResult PostMovie(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Movies.Add(movie);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = movie.id }, movie);
        }

        // DELETE: api/MoviesApi/5
        [ResponseType(typeof(Movie))]
        public IHttpActionResult DeleteMovie(int id)
        {
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            db.Movies.Remove(movie);
            db.SaveChanges();

            return Ok(movie);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MovieExists(int id)
        {
            return db.Movies.Count(e => e.id == id) > 0;
        }
    }
}