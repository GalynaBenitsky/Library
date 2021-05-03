using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Library.Models;

namespace Library.ViewModel
{
    public class RandomBookViewModel
    {
        public Book Book { get; set; }
        public Magazine Magazine { get; set; }
        public List<Reader> Readers { get; set; }

    }
}