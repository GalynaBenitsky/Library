using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonth { get; set; }
        public byte DiscountRate { get; set; }
        public string Name { get; set; }
<<<<<<< HEAD

        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;
=======
>>>>>>> 8011bdefd43f15abf00c541bffa001f56ec48f00
    }
}