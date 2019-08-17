using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace VidlyOrg.Models
{
    //Customer Properties
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }


        public bool DrivingLicence { get; set; }

        [Min3YearsIfADriver]
        [Display(Name = "Release date of driving licence")]
        public DateTime? DrivinLicenceReleaseDate { get; set; }

        //fk
        public MembershipType MembershipType { get; set; }
        [Display(Name = "Membership Type")]
        public int MembershipTypeId { get; set; }

        [Min18YearsIfAMember]
        [Display(Name = "Date of Birth")]
        public DateTime? Birhdate { get; set; }

    }
}