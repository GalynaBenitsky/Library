using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class Min18YearsIfAMembe : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var reader = (Reader)validationContext.ObjectInstance;
            if (reader.MembershipTypeId == MembershipType.Unknown || reader.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;
            if (reader.Birth == null)
                return new ValidationResult("Date of Birth is required");

            var age = DateTime.Today.Year - reader.Birth.Value.Year;

            return (age >= 18) 
                ? ValidationResult.Success 
                : new ValidationResult("Reader shoud be at leat 18 years old to go on a membership");

        }
    }
}