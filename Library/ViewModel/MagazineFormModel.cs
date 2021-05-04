using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Library.Models;

namespace Library.ViewModel
{
    public class MagazineFormModel
    {
        public Magazine Magazine { get; set; }
        

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }


        [Required]
        [Display(Name = "Description")]

        public string desc { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        [Required]
        public byte? NumberInStock { get; set; }

        public string Name
        {
            get
            {
                if (Magazine != null && Magazine.Id != 0)
                    return "Edit Magazine";

                return "New Magazine";
            }
        }
        public MagazineFormModel()
        {
            Id = 0;
        }
        public MagazineFormModel(Magazine magazine)
        {
            Id = magazine.Id;
            Title = magazine.Title;
            desc = magazine.desc;
            ReleaseDate = magazine.ReleaseDate;
            NumberInStock = magazine.NumberInStock;


        }
    }
}