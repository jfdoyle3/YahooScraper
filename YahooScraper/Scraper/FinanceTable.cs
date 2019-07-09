using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ConsoleScraper
{
   public class FinanceTable
    {
        public static void ScrapeToDatabase(List<List<string>> stockData)
        {
            using (StocksContext db = new StocksContext())
            {
                
                for (int i = 0; i < stockData.Count; i++)
                {
                    
                    StockTable stockTable = new StockTable
                    {
                        DateStamp=DateTime.Now,
                        Symbol = stockData[i][0].ToString(),
                        LastPrice = stockData[i][1].ToString(),
                        Change = stockData[i][2].ToString(),
                        ChgPc = stockData[i][3].ToString(),
                        Currency = stockData[i][4].ToString(),
                        MarketTime = stockData[i][5].ToString(),
                        Volume = stockData[i][6].ToString(),
                        AvgVol3m = stockData[i][8].ToString(),
                        MarketCap = stockData[i][12].ToString(),
                    };

                    db.StockTables.Add(stockTable);
                    db.SaveChanges();
                }
                
                Console.WriteLine("\n\nStock data entered into the database.");
                
            }
        }
    }
}
