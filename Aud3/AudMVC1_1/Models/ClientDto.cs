using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AudMVC1_1.Models
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
       public int Age { get; set; }
        public string MovieCard { get; set; }
        public string Telephone { get; set; }
        public bool IsSubscribed { get; set; }

    }
}