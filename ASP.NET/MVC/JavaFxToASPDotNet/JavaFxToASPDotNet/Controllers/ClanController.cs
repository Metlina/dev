using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JavaFxToASPDotNet.Models;

namespace JavaFxToASPDotNet.Controllers
{
    public class ClanController : Controller
    {
        private ClanContext db = new ClanContext();

        // GET: Clan
        public async Task<ActionResult> Index()
        {
            return View(await db.Clans.ToListAsync());
        }

        // GET: Clan/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clan clan = await db.Clans.FindAsync(id);
            if (clan == null)
            {
                return HttpNotFound();
            }
            return View(clan);
        }

        // GET: Clan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Ime,Prezime,Oib")] Clan clan)
        {
            if (ModelState.IsValid)
            {
                db.Clans.Add(clan);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(clan);
        }

        // GET: Clan/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clan clan = await db.Clans.FindAsync(id);
            if (clan == null)
            {
                return HttpNotFound();
            }
            return View(clan);
        }

        // POST: Clan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Ime,Prezime,Oib")] Clan clan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clan).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(clan);
        }

        // GET: Clan/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clan clan = await db.Clans.FindAsync(id);
            if (clan == null)
            {
                return HttpNotFound();
            }
            return View(clan);
        }

        // POST: Clan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Clan clan = await db.Clans.FindAsync(id);
            db.Clans.Remove(clan);
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
