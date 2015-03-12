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
    public class KnjigaController : Controller
    {
        private KnjigaContext db = new KnjigaContext();

        // GET: Knjiga
        public async Task<ActionResult> Index()
        {
            return View(await db.Knjigas.ToListAsync());
        }

        // GET: Knjiga/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Knjiga knjiga = await db.Knjigas.FindAsync(id);
            if (knjiga == null)
            {
                return HttpNotFound();
            }
            return View(knjiga);
        }

        // GET: Knjiga/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Knjiga/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Izdavac,Jezik,Raspolozivost")] Knjiga knjiga)
        {
            if (ModelState.IsValid)
            {
                db.Knjigas.Add(knjiga);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(knjiga);
        }

        // GET: Knjiga/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Knjiga knjiga = await db.Knjigas.FindAsync(id);
            if (knjiga == null)
            {
                return HttpNotFound();
            }
            return View(knjiga);
        }

        // POST: Knjiga/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Izdavac,Jezik,Raspolozivost")] Knjiga knjiga)
        {
            if (ModelState.IsValid)
            {
                db.Entry(knjiga).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(knjiga);
        }

        // GET: Knjiga/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Knjiga knjiga = await db.Knjigas.FindAsync(id);
            if (knjiga == null)
            {
                return HttpNotFound();
            }
            return View(knjiga);
        }

        // POST: Knjiga/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Knjiga knjiga = await db.Knjigas.FindAsync(id);
            db.Knjigas.Remove(knjiga);
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
