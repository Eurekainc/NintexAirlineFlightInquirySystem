using System.Collections.Generic;

namespace NintexAirlineFlightInquirySystem.Library
{
    public class AirlineInquiryProxeyResponse
    {
        public int ResponseCode { get; set; }

        public List<AirlineInquiryProxeyResponseDetails> Result { get; set; }
    }

    public class AirlineInquiryProxeyResponseDetails
    {
        public string AirlineLogoAddress { get; set; }
        public string AirlineName { get; set; }
        public string InboundFlightsDuration { get; set; }
        public string ItineraryId { get; set; }
        public string OutboundFlightsDuration { get; set; }
        public int Stops { get; set; }
        public decimal TotalAmount { get; set; }
    }
}