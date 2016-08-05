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
    public class ProyectoesController : Controller
    {
        private InmosysytemDBEntities4 db = new InmosysytemDBEntities4();

        // GET: Proyectoes
        public ActionResult Index()
        {
            var proyecto = db.Proyecto.Include(p => p.Inmobiliaria);
            return View(proyecto.ToList());
        }

        // GET: Proyectoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proyecto proyecto = db.Proyecto.Find(id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            return View(proyecto);
        }

        // GET: Proyectoes/Create
        public ActionResult Create()
        {
            ViewBag.Inmo_id = new SelectList(db.Inmobiliaria, "Inmo_id", "Inmo_Name");
            return View();
        }

        // POST: Proyectoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Proy_id,Proy_name,Proy_zona,Proy_region,Proy_ciudad,Proy_calle,Proy_gerente,Proy_descripcion,Proy_codigoContable,Inmo_id")] Proyecto proyecto)
        {
            if (ModelState.IsValid)
            {
                db.Proyecto.Add(proyecto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Inmo_id = new SelectList(db.Inmobiliaria, "Inmo_id", "Inmo_Name", proyecto.Inmo_id);
            return View(proyecto);
        }

        // GET: Proyectoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proyecto proyecto = db.Proyecto.Find(id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            ViewBag.Inmo_id = new SelectList(db.Inmobiliaria, "Inmo_id", "Inmo_Name", proyecto.Inmo_id);
            return View(proyecto);
        }

        // POST: Proyectoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Proy_id,Proy_name,Proy_zona,Proy_region,Proy_ciudad,Proy_calle,Proy_gerente,Proy_descripcion,Proy_codigoContable,Inmo_id")] Proyecto proyecto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proyecto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Inmo_id = new SelectList(db.Inmobiliaria, "Inmo_id", "Inmo_Name", proyecto.Inmo_id);
            return View(proyecto);
        }

        // GET: Proyectoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proyecto proyecto = db.Proyecto.Find(id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            return View(proyecto);
        }

        // POST: Proyectoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proyecto proyecto = db.Proyecto.Find(id);
            db.Proyecto.Remove(proyecto);
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
