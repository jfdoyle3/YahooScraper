using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using YahooScraper.Models;
using YahooScraper.Scrapers;

namespace YahooScraper.Controllers
{
    public class HAPController : Controller
    {
        private HapDBContext db = new HapDBContext();

        // GET: HAP
        public async Task<ActionResult> Index()
        {
            return View(await db.HAPStocks.ToListAsync());
        }

        // GET: HAP/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HAPStock hAPStock = await db.HAPStocks.FindAsync(id);
            if (hAPStock == null)
            {
                return HttpNotFound();
            }
            return View(hAPStock);
        }

        // GET: HAP/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HAP/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,DateStamp,Symbol,LastPrice,Change,ChgPc,MarketTime,Volume,AvgVol3m,MarketCap,Method")] HAPStock hAPStock)
        {
            if (ModelState.IsValid)
            {
                db.HAPStocks.Add(hAPStock);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(hAPStock);
        }

        // GET: HAP/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HAPStock hAPStock = await db.HAPStocks.FindAsync(id);
            if (hAPStock == null)
            {
                return HttpNotFound();
            }
            return View(hAPStock);
        }

        // POST: HAP/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,DateStamp,Symbol,LastPrice,Change,ChgPc,MarketTime,Volume,AvgVol3m,MarketCap,Method")] HAPStock hAPStock)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hAPStock).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(hAPStock);
        }

        // GET: HAP/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HAPStock hAPStock = await db.HAPStocks.FindAsync(id);
            if (hAPStock == null)
            {
                return HttpNotFound();
            }
            return View(hAPStock);
        }

        // POST: HAP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            HAPStock hAPStock = await db.HAPStocks.FindAsync(id);
            db.HAPStocks.Remove(hAPStock);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult HAPScrape()
        {
            ViewBag.scrapeStart = "Scraping Please Wait...";
            ViewBag.scrapeMethod = "HAP";
            H  webPage = new YahooFinance();
            List<List<string>> stockTable = webPage.Login();

            //FromFile scrape = new FromFile();
            //List<List<string>> stockTable = scrape.ReadFile();

            ViewBag.stockTable = stockTable;
            ViewBag.scrapeDone = "Done";

            FinanceTable.ScrapeToDatabase(stockTable);

            //int maxId = db.StockTables.Max(p => p.ID);

            //ViewBag.Message = maxId + " Stocks scraped into Database";

            return View();
        }
        public async Task<ActionResult> History()
        {
            return View(await db.StockTables.ToListAsync());
        }

        public ActionResult Reset()
        {
            string query = "DELETE FROM StockTable;" +
                           "DBCC CHECKIDENT(StockTable, RESEED, 0);";

            db.Database.ExecuteSqlCommand(query);

            return RedirectToAction("ViewTable");
        }
        public async Task<ActionResult> ViewTable()
        {
            return View(await db.StockTables.ToListAsync());
        }

    }
}
