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

namespace YahooScraper.Controllers
{
    public class RestSharpStocksController : Controller
    {
        private RestSharpStocksContext db = new RestSharpStocksContext();

        // GET: RestSharpStocks
        public async Task<ActionResult> Index()
        {
            return View(await db.RestSharpStocks.ToListAsync());
        }

        // GET: RestSharpStocks/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestSharpStock restSharpStock = await db.RestSharpStocks.FindAsync(id);
            if (restSharpStock == null)
            {
                return HttpNotFound();
            }
            return View(restSharpStock);
        }

        // GET: RestSharpStocks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RestSharpStocks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,DateStamp,Symbol,Change,MarketTime,ChgPct,Price,Closing,Method")] RestSharpStock restSharpStock)
        {
            if (ModelState.IsValid)
            {
                db.RestSharpStocks.Add(restSharpStock);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(restSharpStock);
        }

        // GET: RestSharpStocks/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestSharpStock restSharpStock = await db.RestSharpStocks.FindAsync(id);
            if (restSharpStock == null)
            {
                return HttpNotFound();
            }
            return View(restSharpStock);
        }

        // POST: RestSharpStocks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,DateStamp,Symbol,Change,MarketTime,ChgPct,Price,Closing,Method")] RestSharpStock restSharpStock)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restSharpStock).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(restSharpStock);
        }

        // GET: RestSharpStocks/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestSharpStock restSharpStock = await db.RestSharpStocks.FindAsync(id);
            if (restSharpStock == null)
            {
                return HttpNotFound();
            }
            return View(restSharpStock);
        }

        // POST: RestSharpStocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            RestSharpStock restSharpStock = await db.RestSharpStocks.FindAsync(id);
            db.RestSharpStocks.Remove(restSharpStock);
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
    }
}
