using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Library.Models;

namespace Library.ViewModel
{
    public class ReaderFormModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Reader Reader { get; set; }

        
    }
}