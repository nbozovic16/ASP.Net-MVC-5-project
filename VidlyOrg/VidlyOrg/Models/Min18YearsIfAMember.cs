using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VidlyOrg.Models
{
    //validation for Birthdate
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if(customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayASYouGo)
            {
                return ValidationResult.Success;
            }


            if(customer.Birhdate == null)
            {
                return new ValidationResult("Birthdate is required!");
            }

            var age = DateTime.Today.Year - customer.Birhdate.Value.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Customer should be at least 18 years old to go on membership.");
        }
    }
}