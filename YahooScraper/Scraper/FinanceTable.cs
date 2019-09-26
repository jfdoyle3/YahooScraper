using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using YahooScraper.Models;

namespace YahooScraper.Scraper
{
   public class FinanceTable
    {
        public static void ScrapeToDatabase(List<List<string>> stockData)
        {
            string method = "HAP";
            using (HapStocksContext db = new HapStocksContext())
            {
                
                for (int i = 0; i < stockData.Count; i++)
                {

                    StockTable stockTable = new StockTable
                    {
                        DateStamp = DateTime.Now,
                        Symbol = stockData[i][0].ToString(),
                        LastPrice = stockData[i][1].ToString(),
                        Change = stockData[i][2].ToString(),
                        ChgPc = stockData[i][3].ToString(),
                        MarketTime = stockData[i][5].ToString(),
                        Volume = stockData[i][6].ToString(),
                        AvgVol3m = stockData[i][8].ToString(),
                        MarketCap = stockData[i][12].ToString(),
                        Method=method,
                    };

                    db.StockTables.Add(stockTable);
                    db.SaveChanges();
                }
            }
        }
    }
}
