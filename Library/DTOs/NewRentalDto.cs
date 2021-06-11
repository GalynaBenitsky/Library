using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.DTOs
{
    public class NewRentalDto
    {
        public int ReaderId { get; set; }
        public List<int> BookIds { get; set; }
       
    }
}