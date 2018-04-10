using AudMVC3_1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AudMVC3_1.Models
{
    public class MoviesDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Client> Clients { get; set; }
        public MoviesDbContext() : base("DefaultConnection")
        {
        }
        public static MoviesDbContext Create()
        {
            return new MoviesDbContext();
        }
    }
}