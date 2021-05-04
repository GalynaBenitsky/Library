using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Library.Models;

namespace Library.ViewModel
{
    public class BookFormNewModel
    {
        public Book Book { get; set; }
        public string Title
        {
            get
            {
                if (Book != null && Book.Id != 0)
                    return "Edit Book";

                return "New Book";
            }
        }
    }
}