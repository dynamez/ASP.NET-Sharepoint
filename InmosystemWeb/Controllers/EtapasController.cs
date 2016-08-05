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
    public class EtapasController : Controller
    {
        private InmosysytemDBEntities4 db = new InmosysytemDBEntities4();

        // GET: Etapas
        public ActionResult Index()
        {
            var etapa = db.Etapa.Include(e => e.Proyecto);
            return View(etapa.ToList());
        }

        // GET: Etapas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etapa etapa = db.Etapa.Find(id);
            if (etapa == null)
            {
                return HttpNotFound();
            }
            return View(etapa);
        }

        // GET: Etapas/Create
        public ActionResult Create()
        {
            ViewBag.Proy_id = new SelectList(db.Proyecto, "Proy_id", "Proy_name");
            return View();
        }

        // POST: Etapas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Etapa_id,Etapa_name,Etapa_tipo,Etapa_inicioCons,Etapa_terminoCons,Etapa_inicioVenta,Etapa_terminoVenta,Etapa_codigoContable,Etapa_unidades,Proy_id")] Etapa etapa)
        {
            if (ModelState.IsValid)
            {
                db.Etapa.Add(etapa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Proy_id = new SelectList(db.Proyecto, "Proy_id", "Proy_name", etapa.Proy_id);
            return View(etapa);
        }

        // GET: Etapas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etapa etapa = db.Etapa.Find(id);
            if (etapa == null)
            {
                return HttpNotFound();
            }
            ViewBag.Proy_id = new SelectList(db.Proyecto, "Proy_id", "Proy_name", etapa.Proy_id);
            return View(etapa);
        }

        // POST: Etapas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Etapa_id,Etapa_name,Etapa_tipo,Etapa_inicioCons,Etapa_terminoCons,Etapa_inicioVenta,Etapa_terminoVenta,Etapa_codigoContable,Etapa_unidades,Proy_id")] Etapa etapa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(etapa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Proy_id = new SelectList(db.Proyecto, "Proy_id", "Proy_name", etapa.Proy_id);
            return View(etapa);
        }

        // GET: Etapas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etapa etapa = db.Etapa.Find(id);
            if (etapa == null)
            {
                return HttpNotFound();
            }
            return View(etapa);
        }

        // POST: Etapas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Etapa etapa = db.Etapa.Find(id);
            db.Etapa.Remove(etapa);
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
