using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VidlyOrg.Models
{
    public class Min3YearsIfADriver : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.DrivingLicence == true)
            {
                
                if (customer.DrivinLicenceReleaseDate == null)
                {
                    return new ValidationResult("Driving licence is required!");
                }

                var age = DateTime.Today.Year - customer.DrivinLicenceReleaseDate.Value.Year;

                return (age >= 3)
                    ? ValidationResult.Success
                    : new ValidationResult("Driving licence should be at older than 3 years.");
            }
            return ValidationResult.Success ;


            
        }
    }
}