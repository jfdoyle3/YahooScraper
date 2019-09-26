using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooScraper.RestSharp
{
    class YahooAuth
    {
        public static void YahooLogin()
        {
            Console.WriteLine("--> Login Authorized Method <--");
            string userName = "jfdoyle_iii";
            string password = "m93Fe8YHn";
            var restClient = new RestClient("https://finance.yahoo.com/portfolio/p_2/view/v1")
            {
                Authenticator = new HttpBasicAuthenticator(userName, password)
            };
            //RestRequest request = new RestRequest("https://apidojo-yahoo-finance-v1.p.rapidapi.com/market/get-summary?region=US&lang=en", Method.GET);
            //request.AddHeader("X-RapidAPI-Host", "apidojo-yahoo-finance-v1.p.rapidapi.com");
            //request.AddHeader("X-RapidAPI-Key", "bd2f89ddc5mshaafba2c2850cce3p1e4c01jsna4733c78a5d4");



        }
    }
}
