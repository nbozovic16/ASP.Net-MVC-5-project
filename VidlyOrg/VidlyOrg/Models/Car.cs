using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyOrg.Models
{
    //Car Properties
    public class Car
    {
        
        public int Id { get; set; }

        [Required]
        [MaxLength(24)]
        public string Brand { get; set; }

        [Required]
        [MaxLength(24)]
        public string Model { get; set; }

        //fk
        public CarBody CarBody { get; set; }
        [Display(Name = "Car body type")]
        public int CarBodyId { get; set; }

        [Required]
        [MaxLength(10)]
        public string Fuel { get; set; }

        [Required]
        public decimal PricePerDay { get; set; }

    }
}