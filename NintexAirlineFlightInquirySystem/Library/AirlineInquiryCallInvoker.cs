using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Threading;
using System.Net;
using System.Collections.Specialized;
using System.Configuration;
using System.Reflection;

namespace NintexAirlineFlightInquirySystem.Library
{
    public class AirlineInquiryCallInvoker
    {
        public async Task<AirlineInquiryProxeyResponse> Call(AirlineInquiryProxeyRequest request)
        {
            AirlineInquiryProxeyResponse response = new AirlineInquiryProxeyResponse();
            
            List<AirlineServiceProvider> providers = (List<AirlineServiceProvider>)HttpContext.Current.Application["AirlineServiceProviders"];

            List<Task<AirlineInquiryProxeyResponse>> tasks = new List<Task<AirlineInquiryProxeyResponse>>();
            foreach (AirlineServiceProvider provider in providers)
            {
                tasks.Add(PostAirlineService(provider, request));
            }

            AirlineInquiryProxeyResponse[] allResponses = await Task.WhenAll(tasks);

            foreach (var res in allResponses)
            {
                if (res != null && res.ResponseCode == (int)HttpStatusCode.OK && res.Result != null && res.Result.Count > 0)
                {
                    if (response.Result == null)
                        response.Result = new List<AirlineInquiryProxeyResponseDetails>();

                    response.Result.AddRange(res.Result);
                }
            }

            if (response.Result != null && response.Result.Count > 0)
                response.ResponseCode = (int)HttpStatusCode.OK;

            return response;
        }

        private async Task<AirlineInquiryProxeyResponse> PostAirlineService(AirlineServiceProvider provider, AirlineInquiryProxeyRequest request)
        {
            AirlineInquiryProxeyResponse response = null;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(provider.URL);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);
                    queryString["DepartureAirportCode"] = request.DepartureAirportCode;
                    queryString["ArrivalAirportCode"] = request.ArrivalAirportCode;
                    queryString["DepartureDate"] = request.DepartureDate;
                    queryString["ReturnDate"] = request.ReturnDate;
                    
                    HttpResponseMessage res = await client.GetAsync(provider.URL + "?" + queryString.ToString());
                    if (res != null)
                    {
                        response = new AirlineInquiryProxeyResponse();
                        response.ResponseCode = (int)res.StatusCode;

                        if (res.IsSuccessStatusCode)
                        {
                            response.Result = provider.ServiceCallParser.ParseJsonResponse(await res.Content.ReadAsStringAsync());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log Exception
            }

            return response;
        }
    }
}