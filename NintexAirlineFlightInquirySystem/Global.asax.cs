using NintexAirlineFlightInquirySystem.Library;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace NintexAirlineFlightInquirySystem
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            LoadAirlineServiceProvidersConfigration();
        }

        private void LoadAirlineServiceProvidersConfigration()
        {
            List<AirlineServiceProvider> providers = new List<AirlineServiceProvider>();

            string[] configs = ConfigurationManager.AppSettings.AllKeys.Where(k => k.StartsWith("Airline")).ToArray();
            foreach (string c in configs)
            {
                string[] data = ConfigurationManager.AppSettings[c].Split(';');
                providers.Add
                (
                    new AirlineServiceProvider()
                    {
                        Name = c,
                        URL = data[0],
                        ServiceCallParser = (BaseAirlineInquiryCallParser)Activator.CreateInstance(Assembly.GetExecutingAssembly().GetTypes().First(t => t.Name == data[1]))
                    }
               );
            }

            Application["AirlineServiceProviders"] = providers;
        }
    }
}
