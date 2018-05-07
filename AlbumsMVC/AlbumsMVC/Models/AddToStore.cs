using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlbumsMVC.Models
{
    public class AddToStore
    {
        public List<Album> albums { get; set; }
        public int selectedAlbum { get; set; }
        public int selectedStore { get; set; }
        public AddToStore()

        {
            albums = new List<Album>();
        }
    }
}