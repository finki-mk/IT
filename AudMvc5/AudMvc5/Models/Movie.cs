using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AudMvc5.Models
{
    public class Movie
    {
        public Movie()
        {
            clients = new List<Client>();
        }
        [Key]
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public float Rating { get; set; }
        [Display (Name ="Download URL")]
        public string DownloadURL { get; set; }
        [Display(Name = "The image URL")]
        public string ImgURL { get; set; }

        public virtual ICollection<Client> clients { get; set; }
    }
}