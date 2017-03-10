using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace NintexAirlineFlightInquirySystem.Library
{
    public class AirlineTwoInquiryCallParser : BaseAirlineInquiryCallParser
    {
        public override string ParseJsonRequest(AirlineInquiryProxeyRequest request)
        {
            return base.ParseJsonRequest(request);
        }

        public override List<AirlineInquiryProxeyResponseDetails> ParseJsonResponse(string json)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();

            dynamic obj = jss.Deserialize<dynamic>(json);

            var list = obj["Results"];

            List<AirlineInquiryProxeyResponseDetails> details = new List<AirlineInquiryProxeyResponseDetails>();
            foreach (var l in list)
            {
                details.Add(new AirlineInquiryProxeyResponseDetails()
                {
                    AirlineLogoAddress = l["AirlineLogoAddress"],
                    AirlineName = l["AirlineName"],
                    InboundFlightsDuration = l["InboundFlightsDuration"],
                    ItineraryId = l["ItineraryId"],
                    OutboundFlightsDuration = l["OutboundFlightsDuration"],
                    Stops = l["Stops"],
                    TotalAmount = l["TotalAmount"],
                });
            }

            return details;
        }
    }
}