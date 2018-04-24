using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AudMvc5.Models
{
    public class Client
    {
        public Client()
        {
            movies = new List<Movie>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Age must be a positive number > 0")]
        public int Age { get; set; }
        public string MovieCard { get; set; }
        public string Telephone { get; set; }
        public bool IsSubscribed { get; set; }

        public virtual ICollection<Movie> movies { get; set; }
    }
}