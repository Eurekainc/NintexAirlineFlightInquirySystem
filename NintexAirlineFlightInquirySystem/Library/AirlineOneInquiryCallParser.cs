using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace NintexAirlineFlightInquirySystem.Library
{
    public class AirlineOneInquiryCallParser : BaseAirlineInquiryCallParser
    {
        public override string ParseJsonRequest(AirlineInquiryProxeyRequest request)
        {
            return base.ParseJsonRequest(request);
        }

        public override List<AirlineInquiryProxeyResponseDetails> ParseJsonResponse(string json)
        {
            return base.ParseJsonResponse(json);
        }
    }
}