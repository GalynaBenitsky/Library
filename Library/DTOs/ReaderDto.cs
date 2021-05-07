using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Library.Models;

namespace Library.DTOs
{
    public class ReaderDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubcribe { get; set; }
       
        public byte MembershipTypeId { get; set; }
        public MembershipTypeDto MembershipType { get; set; }
       
        public DateTime? Birth { get; set; }
    }
}