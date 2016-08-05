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
    public class InmobiliariasController : Controller
    {
        private InmosysytemDBEntities4 db = new InmosysytemDBEntities4();

        // GET: Inmobiliarias
        public ActionResult Index()
        {
           
            return View(db.Inmobiliaria.ToList());
        }

        // GET: Inmobiliarias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inmobiliaria inmobiliaria = db.Inmobiliaria.Find(id);
            if (inmobiliaria == null)
            {
                return HttpNotFound();
            }
            return View(inmobiliaria);
        }

        // GET: Inmobiliarias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inmobiliarias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Inmo_id,Inmo_Name,Inmo_Rut,Inmo_RL,Inmo_Zona,Inmo_Region,Inmo_Ciudad,Inmo_Calle")] Inmobiliaria inmobiliaria)
        {
            if (ModelState.IsValid)
            {
                db.Inmobiliaria.Add(inmobiliaria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inmobiliaria);
        }

        // GET: Inmobiliarias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inmobiliaria inmobiliaria = db.Inmobiliaria.Find(id);
            if (inmobiliaria == null)
            {
                return HttpNotFound();
            }
            return View(inmobiliaria);
        }

        // POST: Inmobiliarias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Inmo_id,Inmo_Name,Inmo_Rut,Inmo_RL,Inmo_Zona,Inmo_Region,Inmo_Ciudad,Inmo_Calle")] Inmobiliaria inmobiliaria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inmobiliaria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inmobiliaria);
        }

        // GET: Inmobiliarias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inmobiliaria inmobiliaria = db.Inmobiliaria.Find(id);
            if (inmobiliaria == null)
            {
                return HttpNotFound();
            }
            return View(inmobiliaria);
        }

        // POST: Inmobiliarias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inmobiliaria inmobiliaria = db.Inmobiliaria.Find(id);
            db.Inmobiliaria.Remove(inmobiliaria);
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
