using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Library.Models;

namespace Library.ViewModel
{
    public class BookFormNewModel
    {
        public Book Book { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        [StringLength(255)]
        public string Author { get; set; }

        [Required]
        [Display(Name ="Genre")]
        
        public string Genre { get; set; }

        [Display(Name="Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name ="Number in Stock")]
        [Range(1,20)]
        [Required]
        public byte? NumberInStock { get; set; }


        public string Name
        {
            get
            {
                if (Book != null && Book.Id != 0)
                    return "Edit Book";

                return "New Book";
            }
        }

        public BookFormNewModel()
        {
            Id = 0;
        }
        public BookFormNewModel(Book book)
        {
            Id = book.Id;
            Title = book.Title;
            Author = book.Author;
            Genre = book.Genre;
            ReleaseDate = book.ReleaseDate;
            NumberInStock = book.NumberInStock;
            

        }
    }
}