using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InmosystemWeb.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;


namespace InmosystemWeb.Controllers
{
    public class CuentasController : Controller
    {
        private InmosysytemDBEntities4 db = new InmosysytemDBEntities4();

        // GET: Cuentas
        public ActionResult Index()
        {
            var cuenta = db.Cuenta.Include(c => c.Etapa).Include(c => c.PlandeCuentas);
            //var cuenta = db.Database.SqlQuery<T>("declare @cols as nvarchar(max), @query as nvarchar(max) select @cols = stuff((select ',' + quotename(convert(char(7), dateadd(month, datediff(month, 0, Cuenta_FechaProceso), 0), 120)) from Cuenta group by Cuenta_FechaProceso order by Cuenta_FechaProceso for xml path(''), type ).value('.', 'nvarchar(max)'),1,1,'') set @query = 'select detalle,' + @cols + ' from ( select PlandeCuentas.Plan_Grupo as [detalle], PlandeCuentas.Plan_Nombre as [nombre],Cuenta.Cuenta_Valor as [valor], convert(char(7), dateadd(month, datediff(month, 0, Cuenta.Cuenta_FechaProceso), 0), 120) as [Fecha] from PlandeCuentas, Cuenta where Cuenta.Plan_Id = PlandeCuentas.Plan_Id) x PIVOT (    sum(valor)    for Fecha in (' + @cols + ')  ) p' execute(@query); ");
            //var cuenta = db.Cuenta.SqlQuery("declare @cols as nvarchar(max), @query as nvarchar(max)select @cols = stuff((select ',' + quotename(convert(char(7), dateadd(month, datediff(month, 0, Cuenta_FechaProceso), 0), 120)) from Cuenta group by Cuenta_FechaProceso order by Cuenta_FechaProceso for xml path(''), type ).value('.', 'nvarchar(max)'),1,1,'') set @query = 'select id,detalle,' + @cols + ' from ( select Cuenta.Cuenta_id as id, PlandeCuentas.Plan_Grupo as [detalle], PlandeCuentas.Plan_Nombre as [nombre],Cuenta.Cuenta_Valor as [valor], convert(char(7), dateadd(month, datediff(month, 0, Cuenta.Cuenta_FechaProceso), 0), 120) as [Fecha] from PlandeCuentas, Cuenta where Cuenta.Plan_Id = PlandeCuentas.Plan_Id) x PIVOT (    sum(valor)    for Fecha in (' + @cols + ')  ) p' execute(@query); ");
            //ViewBag.cuenta = cuenta;
            return View(cuenta);
        }

        // GET: Cuentas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cuenta cuenta = db.Cuenta.Find(id);
            if (cuenta == null)
            {
                return HttpNotFound();
            }
            return View(cuenta);
        }

        // GET: Cuentas/Create
        public ActionResult Create()
        {
            ViewBag.Etapa_id = new SelectList(db.Etapa, "Etapa_id", "Etapa_name");
            ViewBag.Plan_Id = new SelectList(db.PlandeCuentas, "Plan_Id", "Plan_Grupo");
            return View();
        }

        // POST: Cuentas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Cuenta_id,Cuenta_FechaProceso,Cuenta_Valor,Cuenta_CodigoContable,Cuenta_Estado,Cuenta_FechaIngreso,Etapa_id,Plan_Id")] Cuenta cuenta)
        {
            if (ModelState.IsValid)
            {
                db.Cuenta.Add(cuenta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Etapa_id = new SelectList(db.Etapa, "Etapa_id", "Etapa_name", cuenta.Etapa_id);
            ViewBag.Plan_Id = new SelectList(db.PlandeCuentas, "Plan_Id", "Plan_Grupo", cuenta.Plan_Id);
            return View(cuenta);
        }

        // GET: Cuentas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cuenta cuenta = db.Cuenta.Find(id);
            if (cuenta == null)
            {
                return HttpNotFound();
            }
            ViewBag.Etapa_id = new SelectList(db.Etapa, "Etapa_id", "Etapa_name", cuenta.Etapa_id);
            ViewBag.Plan_Id = new SelectList(db.PlandeCuentas, "Plan_Id", "Plan_Grupo", cuenta.Plan_Id);
            return View(cuenta);
        }

        // POST: Cuentas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Cuenta_id,Cuenta_FechaProceso,Cuenta_Valor,Cuenta_CodigoContable,Cuenta_Estado,Cuenta_FechaIngreso,Etapa_id,Plan_Id")] Cuenta cuenta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cuenta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Etapa_id = new SelectList(db.Etapa, "Etapa_id", "Etapa_name", cuenta.Etapa_id);
            ViewBag.Plan_Id = new SelectList(db.PlandeCuentas, "Plan_Id", "Plan_Grupo", cuenta.Plan_Id);
            return View(cuenta);
        }

        // GET: Cuentas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cuenta cuenta = db.Cuenta.Find(id);
            if (cuenta == null)
            {
                return HttpNotFound();
            }
            return View(cuenta);
        }

        // POST: Cuentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cuenta cuenta = db.Cuenta.Find(id);
            db.Cuenta.Remove(cuenta);
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

        [HttpPost]
        public ActionResult Cuentas_Read([DataSourceRequest]DataSourceRequest request)
        {
            using (var northwind = new InmosysytemDBEntities4())
            {
                IQueryable<Cuenta> cuentas = northwind.Cuenta;
                DataSourceResult result = cuentas.ToDataSourceResult(request);
                
                System.Diagnostics.Debug.WriteLine(cuentas.ToDataSourceResult(request).ToString());
                
                return Json(result);
            }
        }
        public ActionResult Cuentas_Update([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<CuentaViewModel> cuentas)
        {
            // Will keep the updated entitites here. Used to return the result later.
            var entities = new List<Cuenta>();
            if (ModelState.IsValid)
            {
                using (var northwind = new InmosysytemDBEntities4())
                {
                    foreach (var cuenta in cuentas)
                    {
                        // Create a new Product entity and set its properties from the posted ProductViewModel.
                        var entity = new Cuenta
                        {
                            Cuenta_id = cuenta.Cuenta_id,
                            Cuenta_FechaProceso = cuenta.Cuenta_FechaProceso,
                            
                            Cuenta_Valor = cuenta.Cuenta_Valor,
                            
                           
                            Etapa = cuenta.Etapa,
                            PlandeCuentas = cuenta.PlandeCuentas,
                            Etapa_id = cuenta.Etapa_id,
                            Plan_Id = cuenta.PlandeCuentas.Plan_Id
                        };
                        // Store the entity for later use.
                        entities.Add(entity);
                        // Attach the entity.
                        northwind.Cuenta.Attach(entity);
                        // Change its state to Modified so Entity Framework can update the existing product instead of creating a new one.
                        northwind.Entry(entity).State = EntityState.Modified;
                        // Or use ObjectStateManager if using a previous version of Entity Framework.
                        // northwind.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                    }
                    // Update the entities in the database.
                    northwind.SaveChanges();
                }
            }
            // Return the updated entities. Also return any validation errors.
            return Json(entities.ToDataSourceResult(request, ModelState, cuenta => new CuentaViewModel
            {
                Cuenta_id = cuenta.Cuenta_id,
                Cuenta_FechaProceso = cuenta.Cuenta_FechaProceso,
                
                Cuenta_Valor = cuenta.Cuenta_Valor,
               
              
                Etapa = cuenta.Etapa,
                PlandeCuentas = cuenta.PlandeCuentas,
                Etapa_id = cuenta.Etapa_id,
                Plan_Id = cuenta.PlandeCuentas.Plan_Id
                
            }));
        }

        public ActionResult Cuentas_Create([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<CuentaViewModel> cuentas)
        {
            // Will keep the inserted entitites here. Used to return the result later.
            var entities = new List<Cuenta>();
            if (ModelState.IsValid)
            {
                using (var northwind = new InmosysytemDBEntities4())
                {
                    foreach (var cuenta in cuentas)
                    {
                        // Create a new Product entity and set its properties from the posted ProductViewModel.
                        var entity = new Cuenta
                        {
                            Cuenta_id = cuenta.Cuenta_id,
                            Cuenta_FechaProceso = cuenta.Cuenta_FechaProceso,
                           
                            Cuenta_Valor = cuenta.Cuenta_Valor,
                            
                            
                            Etapa = cuenta.Etapa,
                            PlandeCuentas = cuenta.PlandeCuentas,
                            Etapa_id = cuenta.Etapa_id,
                            Plan_Id = cuenta.PlandeCuentas.Plan_Id
                        };
                        // Add the entity.
                        northwind.Cuenta.Add(entity);
                        // Store the entity for later use.
                        entities.Add(entity);
                    }
                    // Insert the entities in the database.
                    northwind.SaveChanges();
                }
            }
            // Return the inserted entities. The Grid needs the generated ProductID. Also return any validation errors.
            return Json(entities.ToDataSourceResult(request, ModelState, cuenta => new CuentaViewModel
            {
                Cuenta_id = cuenta.Cuenta_id,
                Cuenta_FechaProceso = cuenta.Cuenta_FechaProceso,
                
                Cuenta_Valor = cuenta.Cuenta_Valor,
                
                Etapa = cuenta.Etapa,
                PlandeCuentas = cuenta.PlandeCuentas,
                Etapa_id = cuenta.Etapa_id,
                Plan_Id = cuenta.PlandeCuentas.Plan_Id
            }));
        }
        public ActionResult Cuentas_Destroy([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<CuentaViewModel> cuentas)
        {
            // Will keep the destroyed entitites here. Used to return the result later.
            var entities = new List<Cuenta>();
            if (ModelState.IsValid)
            {
                using (var northwind = new InmosysytemDBEntities4())
                {
                    foreach (var cuenta in cuentas)
                    {
                        // Create a new Product entity and set its properties from the posted ProductViewModel.
                        var entity = new Cuenta
                        {
                            Cuenta_id = cuenta.Cuenta_id,
                            Cuenta_FechaProceso = cuenta.Cuenta_FechaProceso,
                            
                            Cuenta_Valor = cuenta.Cuenta_Valor,
                            
                            Etapa = cuenta.Etapa,
                            PlandeCuentas = cuenta.PlandeCuentas,
                            Etapa_id = cuenta.Etapa_id,
                            Plan_Id = cuenta.PlandeCuentas.Plan_Id
                        };
                        // Store the entity for later use.
                        entities.Add(entity);
                        // Attach the entity
                        northwind.Cuenta.Attach(entity);
                        // Delete the entity.
                        northwind.Cuenta.Remove(entity);
                        // Or use DeleteObject if using a previous versoin of Entity Framework.
                        // northwind.Products.DeleteObject(entity);
                    }
                    // Delete the entity in the database.
                    northwind.SaveChanges();
                }
            }
            // Return the destroyed entities. Also return any validation errors.
            return Json(entities.ToDataSourceResult(request, ModelState, cuenta => new CuentaViewModel
            {
                Cuenta_id = cuenta.Cuenta_id,
                Cuenta_FechaProceso = cuenta.Cuenta_FechaProceso,
                
                Cuenta_Valor = cuenta.Cuenta_Valor,
                
                Etapa = cuenta.Etapa,
                PlandeCuentas = cuenta.PlandeCuentas,
                Etapa_id = cuenta.Etapa_id,
                Plan_Id = cuenta.PlandeCuentas.Plan_Id
            }));
        }
    }
}
