using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InmosystemWeb.Models;

namespace InmosystemWeb.Controllers
{
    public class PlandeCuentasController : Controller
    {
        private InmosysytemDBEntities4 db = new InmosysytemDBEntities4();

        // GET: PlandeCuentas
        public ActionResult Index()
        {
            return View(db.PlandeCuentas.ToList());
        }

        // GET: PlandeCuentas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlandeCuentas plandeCuentas = db.PlandeCuentas.Find(id);
            if (plandeCuentas == null)
            {
                return HttpNotFound();
            }
            return View(plandeCuentas);
        }

        // GET: PlandeCuentas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlandeCuentas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Plan_Id,Plan_Grupo,Plan_GrupoId,Plan_Nombre,Plan_NombreId")] PlandeCuentas plandeCuentas)
        {
            if (ModelState.IsValid)
            {
                db.PlandeCuentas.Add(plandeCuentas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(plandeCuentas);
        }

        // GET: PlandeCuentas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlandeCuentas plandeCuentas = db.PlandeCuentas.Find(id);
            if (plandeCuentas == null)
            {
                return HttpNotFound();
            }
            return View(plandeCuentas);
        }

        // POST: PlandeCuentas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Plan_Id,Plan_Grupo,Plan_GrupoId,Plan_Nombre,Plan_NombreId")] PlandeCuentas plandeCuentas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plandeCuentas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(plandeCuentas);
        }

        // GET: PlandeCuentas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlandeCuentas plandeCuentas = db.PlandeCuentas.Find(id);
            if (plandeCuentas == null)
            {
                return HttpNotFound();
            }
            return View(plandeCuentas);
        }

        // POST: PlandeCuentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlandeCuentas plandeCuentas = db.PlandeCuentas.Find(id);
            db.PlandeCuentas.Remove(plandeCuentas);
            db.SaveChanges();
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
