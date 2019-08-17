﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyOrg.Models
{
    //CarBody Properties
    public class CarBody
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}