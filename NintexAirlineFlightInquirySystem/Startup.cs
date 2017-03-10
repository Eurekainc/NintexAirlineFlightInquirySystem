using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NintexAirlineFlightInquirySystem.Startup))]
namespace NintexAirlineFlightInquirySystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
