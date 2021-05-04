using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Library.Models;

namespace Library.ViewModel
{
    public class MagazineFormNewModel
    {
        public Magazine Magazine { get; set; }
        public string Title
        {
            get
            {
                if (Magazine != null && Magazine.Id != 0)
                    return "Edit Magazine";

                return "New Magazine";
            }
        }
    }
}