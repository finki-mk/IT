﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AudMVC2_1.Models
{
    public class Client
    {
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
    }
}