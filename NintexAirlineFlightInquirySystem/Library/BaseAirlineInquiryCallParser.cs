using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace NintexAirlineFlightInquirySystem.Library
{
    public abstract class BaseAirlineInquiryCallParser
    {
        public virtual string ParseJsonRequest(AirlineInquiryProxeyRequest request)
        {
            return new JavaScriptSerializer().Serialize(request);
        }

        public virtual List<AirlineInquiryProxeyResponseDetails> ParseJsonResponse(string json)
        {
            return new JavaScriptSerializer().Deserialize<List<AirlineInquiryProxeyResponseDetails>>(json);
        }
    }
}