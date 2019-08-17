using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyOrg.Models;

namespace VidlyOrg.ViewModel
{
    public class CarFormViewModel
    {
        public IEnumerable<CarBody> CarBodies { get; set; }
        public Car Car { get; set; }
        public string Title
        {
            get
            {
                if (Car != null && Car.Id != 0)
                    return "edit car";

                return "new car";
                  
            }

        }
    }
}