using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Title { get; set; }
        public string Genre { get; set; }
        [Required]
        public string Author { get; set; }
        
        public DateTime DateAdded { get; set; }

        [Display(Name ="Relase Date")]
        public DateTime ReleaseDate{get;set;}

        [Display(Name = "Number in Stock")]
        public byte NumberInStock { get; set; }
    }
}