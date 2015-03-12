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
    public class CasopisController : Controller
    {
        private CasopisContext db = new CasopisContext();

        // GET: Casopis
        public async Task<ActionResult> Index()
        {
            return View(await db.Casopis.ToListAsync());
        }

        // GET: Casopis/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Casopis casopis = await db.Casopis.FindAsync(id);
            if (casopis == null)
            {
                return HttpNotFound();
            }
            return View(casopis);
        }

        // GET: Casopis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Casopis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,MjesecIzdavanjaCasopisa")] Casopis casopis)
        {
            if (ModelState.IsValid)
            {
                db.Casopis.Add(casopis);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(casopis);
        }

        // GET: Casopis/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Casopis casopis = await db.Casopis.FindAsync(id);
            if (casopis == null)
            {
                return HttpNotFound();
            }
            return View(casopis);
        }

        // POST: Casopis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,MjesecIzdavanjaCasopisa")] Casopis casopis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(casopis).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(casopis);
        }

        // GET: Casopis/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Casopis casopis = await db.Casopis.FindAsync(id);
            if (casopis == null)
            {
                return HttpNotFound();
            }
            return View(casopis);
        }

        // POST: Casopis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Casopis casopis = await db.Casopis.FindAsync(id);
            db.Casopis.Remove(casopis);
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
