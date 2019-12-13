using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(YahooScraper.Startup))]

namespace YahooScraper
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}