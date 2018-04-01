using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AudMVC2_1.Models
{
    public class MovieRentals
    {
        public Movie movie { get; set; }
        public List<Client> customers { get; set; }
    }
}