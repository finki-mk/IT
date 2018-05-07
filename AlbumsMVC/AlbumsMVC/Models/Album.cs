using AlbumsMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlbumsMVC.Models
{
    public class Album
    {
        public int Id { get; set; }
        public int GenreId { get; set; }
        public int ArtistId { get; set; }
        [Required]
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string AlbumArtUrl { get; set; }
        public Genre Genre { get; set; }
        public Artist Artist { get; set; }
        
        public string Name { get; set; }
        public virtual List<Store> stores { get; set; }
        public Album()
        {
            stores = new List<Store>();
        }
    }
}