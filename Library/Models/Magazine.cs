using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Magazine
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string desc { get; set; }

        public DateTime DateAdded { get; set; }
        [Display(Name = "Relase Date")]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Number in Stock")]
        public byte NumberInStock { get; set; }
    }
}