namespace NintexAirlineFlightInquirySystem.Library
{
    public class AirlineInquiryProxeyRequest
    {
        public string DepartureAirportCode { get; set; }

        public string ArrivalAirportCode { get; set; }

        public string DepartureDate { get; set; }

        public string ReturnDate { get; set; }
    }
}