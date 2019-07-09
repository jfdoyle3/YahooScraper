using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;
using System.IO;
using System.Linq;
using System.Data;


namespace ConsoleScraper
{
    public class FromFile
    {
        public List<List<string>> ReadFile()
        {
            string stocks = File.ReadAllText(@"C:\website\Stocks.htm");
            HtmlDocument yahooPage = new HtmlDocument();

            yahooPage.LoadHtml(stocks);


            List<List<string>> stockTable =
                                    yahooPage.DocumentNode.SelectSingleNode("//table")
                                                .Descendants("tr")
                                                .Skip(1) 
                                                .Where(tr => tr.Elements("td").Count() > 1)
                                                .Select(tr => tr.Elements("td").Select(td => td.InnerText.Trim()).ToList())
                                                .ToList();

            return stockTable;
        }
    }
}
