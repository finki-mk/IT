using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AudMVC2_1.Models
{
    public class Movie
    {
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public float Rating { get; set; }
        [Display (Name ="Download URL")]
        public string DownloadURL { get; set; }
        [Display(Name = "The image URL")]
        public string ImgURL { get; set; }
    }
}