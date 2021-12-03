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
    public class TransaccionesController : Controller
    {
        private CxCEntities db = new CxCEntities();

        // GET: Transacciones
        public ActionResult Index()
        {
            var transacciones = db.Transacciones.Include(t => t.Clientes).Include(t => t.Tipos_Documentos);
            return View(transacciones.ToList());
        }

        // GET: Transacciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transacciones transacciones = db.Transacciones.Find(id);
            if (transacciones == null)
            {
                return HttpNotFound();
            }
            return View(transacciones);
        }

        // GET: Transacciones/Create
        public ActionResult Create()
        {
            ViewBag.Cliente_ID = new SelectList(db.Clientes, "Id", "Nombre");
            ViewBag.TipoDoc_ID = new SelectList(db.Tipos_Documentos, "Id", "Descripcion");
            return View();
        }

        // POST: Transacciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Id_transaccion,Tipo_Mov,TipoDoc_ID,Num_doc,Fecha,Cliente_ID,Monto")] Transacciones transacciones)
        {
            if (ModelState.IsValid)
            {
                db.Transacciones.Add(transacciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cliente_ID = new SelectList(db.Clientes, "Id", "Nombre", transacciones.Cliente_ID);
            ViewBag.TipoDoc_ID = new SelectList(db.Tipos_Documentos, "Id", "Descripcion", transacciones.TipoDoc_ID);
            return View(transacciones);
        }

        // GET: Transacciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transacciones transacciones = db.Transacciones.Find(id);
            if (transacciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cliente_ID = new SelectList(db.Clientes, "Id", "Nombre", transacciones.Cliente_ID);
            ViewBag.TipoDoc_ID = new SelectList(db.Tipos_Documentos, "Id", "Descripcion", transacciones.TipoDoc_ID);
            return View(transacciones);
        }

        // POST: Transacciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Id_transaccion,Tipo_Mov,TipoDoc_ID,Num_doc,Fecha,Cliente_ID,Monto")] Transacciones transacciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transacciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cliente_ID = new SelectList(db.Clientes, "Id", "Nombre", transacciones.Cliente_ID);
            ViewBag.TipoDoc_ID = new SelectList(db.Tipos_Documentos, "Id", "Descripcion", transacciones.TipoDoc_ID);
            return View(transacciones);
        }

        // GET: Transacciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transacciones transacciones = db.Transacciones.Find(id);
            if (transacciones == null)
            {
                return HttpNotFound();
            }
            return View(transacciones);
        }

        // POST: Transacciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transacciones transacciones = db.Transacciones.Find(id);
            db.Transacciones.Remove(transacciones);
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
