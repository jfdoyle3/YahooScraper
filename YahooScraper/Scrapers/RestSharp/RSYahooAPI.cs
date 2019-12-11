using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;

namespace YahooScraper
{
    public class RSYahooAPI
    {
        public static JArray YahooApiScrape()
        {
            Console.Write("Starting:\n Logging in: ");
            RestClient yahoo = new RestClient("https://apidojo-yahoo-finance-v1.p.rapidapi.com");
            RestRequest request = new RestRequest("/market/get-summary?region=US&lang=en", Method.GET);
            request.AddHeader("X-RapidAPI-Host", "apidojo-yahoo-finance-v1.p.rapidapi.com");
            request.AddHeader("X-RapidAPI-Key", "bd2f89ddc5mshaafba2c2850cce3p1e4c01jsna4733c78a5d4");
            Console.Write("Successful\n");
            IRestResponse restResponse = yahoo.Execute(request);

            dynamic jStocks = JsonConvert.DeserializeObject(restResponse.Content);

            JArray stockResult = jStocks["marketSummaryResponse"]["result"];

            Console.WriteLine("\nScraped Data:\n");

            foreach (JToken stock in stockResult)
                Console.WriteLine("{0}  |  {1}  |  {2}  |  {3}  |  {4}  |  {5}  |  {6}", DateTime.Now, stock["symbol"], stock["regularMarketChange"]["fmt"], stock["regularMarketTime"]["fmt"], stock["regularMarketChangePercent"]["fmt"], stock["regularMarketPrice"]["fmt"], stock["regularMarketPreviousClose"]["fmt"]);

            return stockResult;
        }
    }
}