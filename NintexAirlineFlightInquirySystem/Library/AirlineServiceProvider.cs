using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NintexAirlineFlightInquirySystem.Library
{
    public class AirlineServiceProvider
    {
        public string Name { get; set; }

        public string URL { get; set; }

        public BaseAirlineInquiryCallParser ServiceCallParser { get; set; }
    }
}