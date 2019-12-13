using Newtonsoft.Json.Linq;
using System;
using System.Data.Entity

namespace RestSharpEntity
{
    public class EntityWrite
    {
        public static void WriteDB(JArray rsStocks)
        {
            string type = "RS";

            Console.Write("Open\n");
            using (RestSharpStocksContext db = new RestSharpStockContext())
            {
                foreach (JToken stock in rsStocks)
                {
                    RestSharpStock restSharpStock = new RestSharpStock
                    {
                        DateStamp = DateTime.Now,
                        Symbol = stock["symbol"].ToString(),
                        Change = stock["regularMarketChange"]["fmt"].ToString(),
                        MarketTime = stock["regularMarketTime"]["fmt"].ToString(),
                        ChgPct = stock["regularMarketChangePercent"]["fmt"].ToString(),
                        Price = stock["regularMarketPrice"]["fmt"].ToString(),
                        Closing = stock["regularMarketPreviousClose"]["fmt"].ToString(),
                        Method = type,
                    };
                    db.RestSharpStocks.Add(restSharpStock);
                    db.SaveChanges();
                }
            }

            Console.WriteLine("Database: Written and Closed");
        }
    }
}