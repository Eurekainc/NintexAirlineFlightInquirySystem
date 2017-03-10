using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NintexAirlineFlightInquirySystem.Library;
using System.Collections.Generic;

namespace NintexAirlineFlightInquirySystem.Tests.Controllers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestParseJsonRequest()
        {
            AirlineInquiryProxeyRequest req = new AirlineInquiryProxeyRequest();
            req.DepartureAirportCode = "MEl";
            req.ArrivalAirportCode = "LHR";
            req.DepartureDate = "2012-12-24T00:00:00+11:00";
            req.ReturnDate = "2013-01-03T00:00:00+11:00";

            AirlineOneInquiryCallParser parser = new AirlineOneInquiryCallParser();
            string result = parser.ParseJsonRequest(req);

            Assert.AreEqual("{\"DepartureAirportCode\":\"MEl\",\"ArrivalAirportCode\":\"LHR\",\"DepartureDate\":\"2012-12-24T00:00:00+11:00\",\"ReturnDate\":\"2013-01-03T00:00:00+11:00\"}", result);
        }

        [TestMethod]
        public void TestParseJsonResponse()
        {
            string json = "[{"
                  +"\"AirlineLogoAddress\": \"http://nmflightservice.cloudapp.net/Images/AirlineLogo/CZ.gif\","
                  + "\"AirlineName\": \"China Southern Airlines\","
                  +"\"InboundFlightsDuration\": \"24:10\","
                  +"\"ItineraryId\": \"\","
                  +"\"OutboundFlightsDuration\": \"26:20\","
                  +"\"Stops\": 2,"
                  +"\"TotalAmount\": 2903.84"
                  +"}]";

            AirlineOneInquiryCallParser parser = new AirlineOneInquiryCallParser();
            List<AirlineInquiryProxeyResponseDetails> result = parser.ParseJsonResponse(json);

            Assert.AreEqual("{\"DepartureAirportCode\":\"MEl\",\"ArrivalAirportCode\":\"LHR\",\"DepartureDate\":\"2012-12-24T00:00:00+11:00\",\"ReturnDate\":\"2013-01-03T00:00:00+11:00\"}", result);
        }

        [TestMethod]
        public void TestCall()
        {
            AirlineInquiryProxeyRequest req = new AirlineInquiryProxeyRequest();
            req.DepartureAirportCode = "MEl";
            req.ArrivalAirportCode = "LHR";
            req.DepartureDate = "2012-12-24T00:00:00+11:00";
            req.ReturnDate = "2013-01-03T00:00:00+11:00";

            AirlineInquiryCallInvoker invoker = new AirlineInquiryCallInvoker();
            AirlineInquiryProxeyResponse res = invoker.Call(req).Result;

            Assert.AreEqual(200, res.ResponseCode);
        }
    }
}
