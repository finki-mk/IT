using AlbumsMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlbumsMVC.Models
{
    public class Store
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual List<Album> albums { get; set; }
        public Store()
        {
            albums = new List<Album>();
        }
    }
}