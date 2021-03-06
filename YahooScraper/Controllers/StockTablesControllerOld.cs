﻿//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using YahooScraper.Models;
//using YahooScraper.Scraper;

//namespace YahooScraper.Controllers
//{
//    public class StockTablesControllerOld : Controller
//    {
//        private HapStocksContext db = new HapStocksContext();

//        // GET: StockTables
//        public async Task<ActionResult> Index()
//        {
//            return View(await db.StockTables.ToListAsync());
//        }

//        // GET: StockTables/Details/5
//        public async Task<ActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            StockTable stockTable = await db.StockTables.FindAsync(id);
//            if (stockTable == null)
//            {
//                return HttpNotFound();
//            }
//            return View(stockTable);
//        }

//        // GET: StockTables/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: StockTables/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<ActionResult> Create([Bind(Include = "ID,DateStamp,Symbol,LastPrice,Change,ChgPc,MarketTime,Volume,AvgVol3m,MarketCap,Method")] StockTable stockTable)
//        {
//            if (ModelState.IsValid)
//            {
//                db.StockTables.Add(stockTable);
//                await db.SaveChangesAsync();
//                return RedirectToAction("Index");
//            }

//            return View(stockTable);
//        }

//        // GET: StockTables/Edit/5
//        public async Task<ActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            StockTable stockTable = await db.StockTables.FindAsync(id);
//            if (stockTable == null)
//            {
//                return HttpNotFound();
//            }
//            return View(stockTable);
//        }

//        // POST: StockTables/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<ActionResult> Edit([Bind(Include = "ID,DateStamp,Symbol,LastPrice,Change,ChgPc,MarketTime,Volume,AvgVol3m,MarketCap,Method")] StockTable stockTable)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(stockTable).State = EntityState.Modified;
//                await db.SaveChangesAsync();
//                return RedirectToAction("Index");
//            }
//            return View(stockTable);
//        }

//        // GET: StockTables/Delete/5
//        public async Task<ActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            StockTable stockTable = await db.StockTables.FindAsync(id);
//            if (stockTable == null)
//            {
//                return HttpNotFound();
//            }
//            return View(stockTable);
//        }

//        // POST: StockTables/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<ActionResult> DeleteConfirmed(int id)
//        {
//            StockTable stockTable = await db.StockTables.FindAsync(id);
//            db.StockTables.Remove(stockTable);
//            await db.SaveChangesAsync();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//        //     [Authorize]
//        public ActionResult Scrape()
//        {
//            ViewBag.scrapeStart = "Scraping Plase Wait...";
//            ViewBag.scrapeMethod = "HAP";
//            YahooFinance webPage = new YahooFinance();
//            List<List<string>> stockTable = webPage.Login();

//            //FromFile scrape = new FromFile();
//            //List<List<string>> stockTable = scrape.ReadFile();

//            ViewBag.stockTable = stockTable;
//            ViewBag.scrapeDone = "Done";

//            FinanceTable.ScrapeToDatabase(stockTable);

//            //int maxId = db.StockTables.Max(p => p.ID);

//            //ViewBag.Message = maxId + " Stocks scraped into Database";

//            return View();
//        }
//        public async Task<ActionResult> History()
//        {
//            return View(await db.StockTables.ToListAsync());
//        }

//        public ActionResult Reset()
//        {
//            string query = "DELETE FROM StockTable;" +
//                           "DBCC CHECKIDENT(StockTable, RESEED, 0);";

//            db.Database.ExecuteSqlCommand(query);

//            return RedirectToAction("ViewTable");
//        }
//        public async Task<ActionResult> ViewTable()
//        {
//            return View(await db.StockTables.ToListAsync());
//        }

//    }
//}