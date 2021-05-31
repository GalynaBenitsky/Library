using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Rental
    {
        public int Id { get; set; }
        [Required]
        public Reader Reader { get; set; }
        [Required]
        public Book Book { get; set; }
        [Required]
        public Magazine Magazine { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime? DateReturned { get; set; }
    }
}