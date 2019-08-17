using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyOrg.Models
{
    //MembershipType Properties
    public class MembershipType
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string SignUpFee { get; set; }
        public int DurationInMonths { get; set; }
        public int DiscountRate { get; set; }

        //for validation
        public static readonly byte Unknown = 0;
        public static readonly byte PayASYouGo = 1;
    }
}