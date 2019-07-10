using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YahooScraper.Scraper;

namespace YahooScraper.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        public ActionResult Index()
        {
            return View();
        }

        // 
        // GET: /HelloWorld/Welcome/ 

        // add ?name=Scott&numtimes=4 to the end of URL
        public ActionResult Welcome(string name, int numTimes = 1)
        {
            ViewBag.Message = "Hello " + name;
            ViewBag.NumTimes = numTimes;

            return View();
        }
        public ActionResult CProg()
        {
            ViewBag.Message="ViewBag";

            return View();
        }

        public ActionResult Scrape()
        {
            YahooFinance scrape = new YahooFinance();
            List<List<string>> stockTable = scrape.Login();

            // FinanceTable.ScrapeToDatabase(stockTable);

            return View(); 
        }
    }
}