using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CxCSystem.Models;

namespace CxCSystem.Controllers
{
    public class AsientosController : Controller
    {
        private CxCEntities db = new CxCEntities();

        // GET: Asientos
        public ActionResult Index()
        {
            var asientos = db.Asientos.Include(a => a.Clientes);
            return View(asientos.ToList());
        }

        // GET: Asientos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asientos asientos = db.Asientos.Find(id);
            if (asientos == null)
            {
                return HttpNotFound();
            }
            return View(asientos);
        }

        // GET: Asientos/Create
        public ActionResult Create()
        {
            ViewBag.Cliente_ID = new SelectList(db.Clientes, "Id", "Nombre");
            return View();
        }

        // POST: Asientos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Id_Asiento,Descripcion,Cliente_ID,Cuenta,Tipo_movimiento,Fecha,Monto,Estado")] Asientos asientos)
        {
            if (ModelState.IsValid)
            {
                db.Asientos.Add(asientos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cliente_ID = new SelectList(db.Clientes, "Id", "Nombre", asientos.Cliente_ID);
            return View(asientos);
        }

        // GET: Asientos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asientos asientos = db.Asientos.Find(id);
            if (asientos == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cliente_ID = new SelectList(db.Clientes, "Id", "Nombre", asientos.Cliente_ID);
            return View(asientos);
        }

        // POST: Asientos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Id_Asiento,Descripcion,Cliente_ID,Cuenta,Tipo_movimiento,Fecha,Monto,Estado")] Asientos asientos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asientos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cliente_ID = new SelectList(db.Clientes, "Id", "Nombre", asientos.Cliente_ID);
            return View(asientos);
        }

        // GET: Asientos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asientos asientos = db.Asientos.Find(id);
            if (asientos == null)
            {
                return HttpNotFound();
            }
            return View(asientos);
        }

        // POST: Asientos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asientos asientos = db.Asientos.Find(id);
            db.Asientos.Remove(asientos);
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
