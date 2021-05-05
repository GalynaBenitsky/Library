using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace Library.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Title { get; set; }
        public string Genre { get; set; }
        
        public string Author { get; set; }

        public DateTime DateAdded { get; set; }

       
        public DateTime ReleaseDate { get; set; }

        
        [Range(1, 20)]
        public byte NumberInStock { get; set; }
    }
}